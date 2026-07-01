using ChatShared.Models;
using ChatShared.Protocol;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Message = ChatShared.Models.Message;

namespace ChatServer.Core;

public class ClientHandler
{
    private readonly TcpClient _tcpClient;
    private readonly TcpServer _server;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public User User { get; private set; } = new();

    public ClientHandler(TcpClient tcpClient, TcpServer server)
    {
        _tcpClient = tcpClient;
        _server = server;
    }

    public async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            var stream = _tcpClient.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };

            // Đọc message đầu tiên — phải là type Join
            var firstLine = await _reader.ReadLineAsync(ct);
            if (firstLine == null) return;

            var joinMsg = Message.FromJson(firstLine);
            if (joinMsg == null || joinMsg.Type != MessageType.Join) return;

            // Tạo phòng nếu chưa tồn tại
            if (!_server.RoomManager.RoomExists(joinMsg.Room))
                _server.RoomManager.CreateRoom(joinMsg.Room);

            // Lưu thông tin user
            User.Username = joinMsg.Username;
            User.DisplayName = string.IsNullOrWhiteSpace(joinMsg.DisplayName) ? joinMsg.Username : joinMsg.DisplayName.Trim();
            User.CurrentRoom = joinMsg.Room;
            User.IsOnline = true;

            // Đăng ký client vào danh sách server
            _server.Clients[User.Username] = this;
            _server.UserManager.AddUser(User); // ← Thêm vào UserManager
            _server.Log($"JOIN — {User.DisplayName} → #{User.CurrentRoom}");
            _server.NotifyClientChanged(User.DisplayName, true);

            // Gửi danh sách phòng cho client mới vào
            await _server.SendRoomListAsync(this);
            await _server.SendRoomHistoryAsync(this, User.CurrentRoom);

            // Thông báo cho cả phòng có người mới vào
            await _server.BroadcastToRoomAsync(new Message
            {
                Type = MessageType.Join,
                Username = User.Username,
                DisplayName = User.DisplayName,
                Room = User.CurrentRoom,
                Content = $"{User.DisplayName} đã tham gia phòng"
            }, User.CurrentRoom);

            await _server.BroadcastRoomUsersAsync(User.CurrentRoom);

            // Vòng lặp đọc message liên tục
            string? line;
            while ((line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg == null) continue;

                switch (msg.Type)
                {
                    case MessageType.Chat:
                        msg.Room = msg.Room.Trim().TrimStart('#').ToLower();
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
                                await SendMessageAsync(new Message
                                {
                                    Type = MessageType.Error,
                                    Content = "Tên hiện thị không hợp lệ."
                                });
                                break;
                            }

                            User.DisplayName = newDisplayName;
                            _server.UserManager.UpdateDisplayName(User.Username, newDisplayName);

                            _server.Log($"UPDATE DISPLAY NAME - {oldDisplayName} -> {newDisplayName}");

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
            // Dọn dẹp khi client ngắt kết nối
            _server.Clients.TryRemove(User.Username, out _);
            _server.UserManager.RemoveUser(User.Username); // ← Thêm remove khỏi UserManager
            _server.NotifyClientChanged(User.Username, false);
            _server.Log($"DISCONNECT — {User.Username}");

            // Thông báo cho cả phòng
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

    // Gửi 1 message tới client này
    public async Task SendMessageAsync(Message message)
    {
        try
        {
            if (_writer == null) return;
            await _writer.WriteLineAsync(message.ToJson());
        }
        catch
        {
            // Client đã ngắt kết nối, bỏ qua
        }
    }

    private async Task HandleCreateRoomAsync(Message msg)
    {
        try
        {
            Room? room = System.Text.Json.JsonSerializer.Deserialize<Room>(msg.Content ?? "");

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

            await _server.BroadcastRoomListAsync();
        }
        catch (Exception ex)
        {
            _server.Log($"CREATE ROOM ERROR — {User.DisplayName}: {ex.Message}");
            await SendErrorAsync("Server không thể tạo phòng.");
        }
    }

    private async Task HandleJoinRoomAsync(Message msg)
    {
        string oldRoom = NormalizeRoomName(User.CurrentRoom);
        string newRoom = NormalizeRoomName(msg.Room);

        if (string.IsNullOrWhiteSpace(newRoom))
        {
            await SendErrorAsync("Tên phòng không hợp lệ.");
            return;
        }

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

        if (!_server.RoomManager.CanJoinRoom(newRoom, currentMembers, out string errorMessage))
        {
            await SendErrorAsync(errorMessage, newRoom);

            _server.Log($"JOIN REJECTED — {User.DisplayName} không thể vào #{newRoom}: {errorMessage}");

            return;
        }

        await _server.BroadcastToRoomAsync(new Message
        {
            Type = MessageType.Leave,
            Username = User.Username,
            DisplayName = User.DisplayName,
            Room = oldRoom,
            Content = $"{User.DisplayName} đã rời phòng"
        }, oldRoom);

        _server.UserManager.ChangeRoom(User.Username, newRoom);
        User.CurrentRoom = newRoom;

        await _server.SendRoomHistoryAsync(this, newRoom);

        await _server.BroadcastToRoomAsync(new Message
        {
            Type = MessageType.Join,
            Username = User.Username,
            DisplayName = User.DisplayName,
            Room = newRoom,
            Content = $"{User.DisplayName} đã tham gia phòng"
        }, newRoom);

        _server.Log($"CHANGE ROOM — {User.DisplayName}: #{oldRoom} → #{newRoom}");

        await _server.BroadcastRoomUsersAsync(oldRoom);
        await _server.BroadcastRoomUsersAsync(newRoom);
    }

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

    private string NormalizeRoomName(string roomName)
    {
        return roomName.Trim().TrimStart('#').ToLower();
    }
}