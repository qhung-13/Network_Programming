using System;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;

namespace ChatServer.Core;

/// <summary>
/// Manages the lifecycle, incoming messages, and outgoing broadcasts for a single connected client.
/// Acts as the bridge between the raw TCP stream and the server's centralized managers.
/// </summary>
public class ClientHandler
{
    #region Fields & Properties

    private readonly TcpClient _tcpClient;
    private readonly TcpServer _server;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    /// <summary>
    /// Represents the authenticated user profile associated with this connection.
    /// </summary>
    public User User { get; private set; } = new();

    #endregion

    #region Constructor

    public ClientHandler(TcpClient tcpClient, TcpServer server)
    {
        _tcpClient = tcpClient;
        _server = server;
    }

    #endregion

    #region Main Connection Lifecycle

    /// <summary>
    /// Initiates the listener loop to process incoming network payloads continuously 
    /// until the client disconnects or cancellation is requested.
    /// </summary>
    public async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var stream = _tcpClient.GetStream();
            _reader = new StreamReader(stream);
            // AutoFlush ensures payloads are dispatched immediately without manual flushing
            _writer = new StreamWriter(stream) { AutoFlush = true };

            // --- 1. Initial Handshake & Authentication ---

            // Await the initial handshake payload, which must strictly be a Join message
            var firstLine = await _reader.ReadLineAsync(ct);
            if (firstLine == null) return;

            var joinMsg = Message.FromJson(firstLine);
            if (joinMsg == null || joinMsg.Type != MessageType.Join) return;

            // Ensure the requested default room exists before routing the user
            if (!_server.RoomManager.RoomExists(joinMsg.Room))
            {
                _server.RoomManager.CreateRoom(joinMsg.Room);
            }

            // Populate the session's user profile
            User.Username = joinMsg.Username;
            User.DisplayName = string.IsNullOrWhiteSpace(joinMsg.DisplayName) ? joinMsg.Username : joinMsg.DisplayName.Trim();
            User.CurrentRoom = joinMsg.Room;
            User.IsOnline = true;

            // Register the authenticated client into the server's tracking dictionaries
            _server.Clients[User.Username] = this;
            _server.UserManager.AddUser(User);

            _server.Log($"JOIN — {User.DisplayName} → #{User.CurrentRoom}");
            _server.NotifyClientChanged(User.DisplayName, true);

            // Synchronize initial state: Room list and history for the newly joined room
            await _server.SendRoomListAsync(this);
            await _server.SendRoomHistoryAsync(this, User.CurrentRoom);

            // Announce the new arrival to all existing members in the target room
            await _server.BroadcastToRoomAsync(new Message
            {
                Type = MessageType.Join,
                Username = User.Username,
                DisplayName = User.DisplayName,
                Room = User.CurrentRoom,
                Content = $"{User.DisplayName} đã tham gia phòng"
            }, User.CurrentRoom);

            await _server.BroadcastRoomUsersAsync(User.CurrentRoom);

            // --- 2. Continuous Listening Loop ---

            string? line;
            while ((line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg == null) continue;

                // Route the incoming message based on its protocol type
                switch (msg.Type)
                {
                    case MessageType.Chat:
                        msg.Room = NormalizeRoomName(msg.Room);
                        msg.Username = User.Username;
                        msg.DisplayName = User.DisplayName;
                        msg.Time = DateTime.Now;

                        _server.RoomManager.AddMessage(msg);
                        _server.Log($"MSG — {User.DisplayName} → #{msg.Room}: \"{msg.Content}\"");
                        await _server.BroadcastToRoomAsync(msg, msg.Room);
                        break;

                    case MessageType.Join:
                        await HandleJoinRoomAsync(msg);
                        break;

                    case MessageType.CreateRoom:
                        await HandleCreateRoomAsync(msg);
                        break;

                    case MessageType.GetRooms:
                        await _server.SendRoomListAsync(this);
                        break;

                    case MessageType.GetRoomHistory:
                        await _server.SendRoomHistoryAsync(this, msg.Room);
                        break;

                    case MessageType.UpdateDisplayName:
                        {
                            string oldDisplayName = User.DisplayName;
                            string newDisplayName = !string.IsNullOrWhiteSpace(msg.DisplayName) ? msg.DisplayName.Trim() : msg.Content.Trim();

                            if (string.IsNullOrWhiteSpace(newDisplayName))
                            {
                                await SendErrorAsync("Tên hiện thị không hợp lệ.");
                                break;
                            }

                            User.DisplayName = newDisplayName;
                            _server.UserManager.UpdateDisplayName(User.Username, newDisplayName);

                            _server.Log($"UPDATE DISPLAY NAME - {oldDisplayName} -> {newDisplayName}");

                            // Broadcast the name change event as a system message in the current room
                            await _server.BroadcastToRoomAsync(new Message
                            {
                                Type = MessageType.Join,
                                Username = User.Username,
                                DisplayName = User.DisplayName,
                                Room = User.CurrentRoom,
                                Content = $"{oldDisplayName} đã đổi tên thành {newDisplayName}"
                            }, User.CurrentRoom);

                            await _server.BroadcastRoomUsersAsync(User.CurrentRoom);
                            break;
                        }
                }
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _server.Log($"ERROR — {User.Username}: {ex.Message}");
        }
        finally
        {
            // --- 3. Resource Teardown & Disconnection ---

            // Cleanly remove the client from global server registries
            _server.Clients.TryRemove(User.Username, out _);
            _server.UserManager.RemoveUser(User.Username);
            _server.NotifyClientChanged(User.Username, false);

            _server.Log($"DISCONNECT — {User.Username}");

            // Broadcast departure to the current room members
            await _server.BroadcastToRoomAsync(new Message
            {
                Type = MessageType.Leave,
                Username = User.Username,
                Room = User.CurrentRoom,
                Content = $"{User.Username} đã rời phòng"
            }, User.CurrentRoom);

            await _server.BroadcastRoomUsersAsync(User.CurrentRoom);

            _tcpClient.Close();
        }
    }

    #endregion

    #region Message Processors

    /// <summary>
    /// Processes a request to create a new chat room, validating limits and availability.
    /// </summary>
    private async Task HandleCreateRoomAsync(Message msg)
    {
        try
        {
            Room? room = JsonSerializer.Deserialize<Room>(msg.Content ?? "");

            if (room == null || string.IsNullOrWhiteSpace(room.RoomName))
            {
                await SendErrorAsync("Thông tin phòng không hợp lệ.");
                return;
            }

            room.RoomName = NormalizeRoomName(room.RoomName);

            if (room.MaxMembers < 0 || room.MaxMembers > 100)
            {
                await SendErrorAsync("Giới hạn thành viên phải từ 1 đến 100, hoặc 0 nếu không giới hạn.");
                return;
            }

            bool created = _server.RoomManager.CreateRoom(room);

            if (!created)
            {
                await SendErrorAsync($"Phòng #{room.RoomName} đã tồn tại.");
                return;
            }

            _server.Log($"CREATE ROOM — {User.DisplayName} tạo #{room.RoomName}, MaxMembers={room.MaxMembers}");

            // Notify all connected clients about the newly available room
            await _server.BroadcastRoomListAsync();
        }
        catch (Exception ex)
        {
            _server.Log($"CREATE ROOM ERROR — {User.DisplayName}: {ex.Message}");
            await SendErrorAsync("Server không thể tạo phòng.");
        }
    }

    /// <summary>
    /// Processes a request to switch rooms, verifying existence and capacity constraints.
    /// </summary>
    private async Task HandleJoinRoomAsync(Message msg)
    {
        string oldRoom = NormalizeRoomName(User.CurrentRoom);
        string newRoom = NormalizeRoomName(msg.Room);

        if (string.IsNullOrWhiteSpace(newRoom))
        {
            await SendErrorAsync("Tên phòng không hợp lệ.");
            return;
        }

        // Prevent redundant processing if the user is already in the target room
        if (newRoom == oldRoom)
        {
            return;
        }

        if (!_server.RoomManager.RoomExists(newRoom))
        {
            await SendErrorAsync($"Phòng #{newRoom} không tồn tại.");
            return;
        }

        int currentMembers = _server.UserManager.GetUsersInRoom(newRoom).Count;

        // Verify if the target room has reached its maximum capacity
        if (!_server.RoomManager.CanJoinRoom(newRoom, currentMembers, out string errorMessage))
        {
            await SendErrorAsync(errorMessage, newRoom);
            _server.Log($"JOIN REJECTED — {User.DisplayName} không thể vào #{newRoom}: {errorMessage}");
            return;
        }

        // 1. Announce departure from the old room
        await _server.BroadcastToRoomAsync(new Message
        {
            Type = MessageType.Leave,
            Username = User.Username,
            DisplayName = User.DisplayName,
            Room = oldRoom,
            Content = $"{User.DisplayName} đã rời phòng"
        }, oldRoom);

        // 2. Update user state and tracking
        _server.UserManager.ChangeRoom(User.Username, newRoom);
        User.CurrentRoom = newRoom;

        // 3. Push historical context to the user
        await _server.SendRoomHistoryAsync(this, newRoom);

        // 4. Announce arrival in the new room
        await _server.BroadcastToRoomAsync(new Message
        {
            Type = MessageType.Join,
            Username = User.Username,
            DisplayName = User.DisplayName,
            Room = newRoom,
            Content = $"{User.DisplayName} đã tham gia phòng"
        }, newRoom);

        _server.Log($"CHANGE ROOM — {User.DisplayName}: #{oldRoom} → #{newRoom}");

        // 5. Sync active user lists for both affected rooms
        await _server.BroadcastRoomUsersAsync(oldRoom);
        await _server.BroadcastRoomUsersAsync(newRoom);
    }

    #endregion

    #region Network Helpers

    /// <summary>
    /// Serializes and transmits a single message payload to this specific client.
    /// </summary>
    public async Task SendMessageAsync(Message message)
    {
        try
        {
            if (_writer == null) return;
            await _writer.WriteLineAsync(message.ToJson());
        }
        catch
        {
            // Silently swallow exceptions here: if the writer fails, the client has likely 
            // disconnected abruptly. The main listening loop will catch it and trigger teardown.
        }
    }

    /// <summary>
    /// Constructs and dispatches a standardized error message back to the client.
    /// </summary>
    private async Task SendErrorAsync(string content, string? roomName = null)
    {
        await SendMessageAsync(new Message
        {
            Type = MessageType.Error,
            Username = User.Username,
            DisplayName = User.DisplayName,
            Room = string.IsNullOrWhiteSpace(roomName) ? User.CurrentRoom : roomName,
            Content = content,
            Time = DateTime.Now
        });
    }

    /// <summary>
    /// Sanitizes room names to ensure consistent routing keys (lowercase, no leading hash).
    /// </summary>
    private string NormalizeRoomName(string roomName)
    {
        return roomName.Trim().TrimStart('#').ToLower();
    }

    #endregion
}