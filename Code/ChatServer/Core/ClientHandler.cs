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
                        // Xử lý chuyển phòng
                        var oldRoom = User.CurrentRoom;
                        if (!_server.RoomManager.RoomExists(msg.Room))
                            _server.RoomManager.CreateRoom(msg.Room);

                        // Thông báo leave phòng cũ
                        await _server.BroadcastToRoomAsync(new Message
                        {
                            Type = MessageType.Leave,
                            Username = User.Username,
                            DisplayName = User.DisplayName,
                            Room = oldRoom,
                            Content = $"{User.DisplayName} đã rời phòng"
                        }, oldRoom);

                        // Cập nhật phòng mới — UserManager và User
                        _server.UserManager.ChangeRoom(User.Username, msg.Room); // ← Sửa chữ U hoa
                        User.CurrentRoom = msg.Room;

                        msg.Room = msg.Room.Trim().TrimStart('#').ToLower();
                        _server.UserManager.ChangeRoom(User.Username, msg.Room);
                        User.CurrentRoom = msg.Room;

                        await _server.SendRoomHistoryAsync(this, User.CurrentRoom);

                        // Thông báo join phòng mới
                        await _server.BroadcastToRoomAsync(new Message
                        {
                            Type = MessageType.Join,
                            Username = User.Username,
                            DisplayName = User.DisplayName,
                            Room = msg.Room,
                            Content = $"{User.DisplayName} đã tham gia phòng" 
                        }, msg.Room);

                        _server.Log($"CHANGE ROOM — {User.DisplayName}: #{oldRoom} → #{msg.Room}");

                        await _server.BroadcastRoomUsersAsync(oldRoom);
                        await _server.BroadcastRoomUsersAsync(msg.Room);
                        break;

                    case MessageType.CreateRoom:
                        try
                        {
                            var room = System.Text.Json.JsonSerializer.Deserialize<Room>(msg.Content ?? "");

                            if (room.Maxmembers < 0 || room.Maxmembers > 100)
                            {
                                await SendMessageAsync(new Message
                                {
                                    Type = MessageType.Error,
                                    Content = "Giới hạn thành viên phải từ 1 đến 100, hoặc 0 nếu không giới hạn."
                                });
                                break;
                            }

                            if (room == null || string.IsNullOrWhiteSpace(room.RoomName))
                            {
                                await SendMessageAsync(new Message
                                {
                                    Type = MessageType.Error,
                                    Content = "Thông tin phòng không hợp lệ."
                                });
                                break;
                            }

                            room.RoomName = room.RoomName.Trim().TrimStart('#').ToLower();

                            bool created = _server.RoomManager.CreateRoom(room);

                            if(!created)
                            {
                                await SendMessageAsync(new Message
                                {
                                    Type = MessageType.Error,
                                    Content = $"Phòng #{room.RoomName} đã tồn tại."
                                });
                                break;
                            }

                            _server.Log($"CREATED ROOM - {User.Username} tạo #{room.RoomName}");

                            await _server.BroadcastRoomListAsync();
                        }
                        catch
                        {
                            await SendMessageAsync(new Message
                            {
                                Type = MessageType.Error,
                                Content = "Server không thể tạo phòng."
                            });
                        }
                        break;
                        //if (_server.RoomManager.CreateRoom(msg.Content))
                        //    _server.Log($"CREATE ROOM — {User.Username} tạo #{msg.Content}"); // ← Thêm dấu ;
                        //break;

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
}