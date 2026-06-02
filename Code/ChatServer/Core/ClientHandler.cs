using ChatShared.Models;
using ChatShared.Protocol;
using System.Net.Sockets;
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
            User.CurrentRoom = joinMsg.Room;
            User.IsOnline = true;

            // Đăng ký client vào danh sách server
            _server.Clients[User.Username] = this;
            _server.UserManager.AddUser(User); // ← Thêm vào UserManager
            _server.Log($"JOIN — {User.Username} → #{User.CurrentRoom}");
            _server.NotifyClientChanged(User.Username, true);

            // Gửi danh sách phòng cho client mới vào
            await _server.SendRoomListAsync(this); // ← Thêm dấu ; ở đây

            // Thông báo cho cả phòng có người mới vào
            await _server.BroadcastToRoomAsync(new Message
            {
                Type = MessageType.Join,
                Username = User.Username,
                Room = User.CurrentRoom,
                Content = $"{User.Username} đã tham gia phòng"
            }, User.CurrentRoom);

            // Vòng lặp đọc message liên tục
            string? line;
            while ((line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg == null) continue;

                switch (msg.Type)
                {
                    case MessageType.Chat:
                        _server.Log($"MSG — {User.Username} → #{msg.Room}: \"{msg.Content}\"");
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
                            Room = oldRoom,
                            Content = $"{User.Username} đã rời phòng"
                        }, oldRoom);

                        // Cập nhật phòng mới — UserManager và User
                        _server.UserManager.ChangeRoom(User.Username, msg.Room); // ← Sửa chữ U hoa
                        User.CurrentRoom = msg.Room;

                        // Thông báo join phòng mới
                        await _server.BroadcastToRoomAsync(new Message
                        {
                            Type = MessageType.Join,
                            Username = User.Username,
                            Room = msg.Room,
                            Content = $"{User.Username} đã tham gia phòng" // ← Đổi sang tiếng Việt
                        }, msg.Room);

                        _server.Log($"CHANGE ROOM — {User.Username}: #{oldRoom} → #{msg.Room}");
                        break;

                    case MessageType.CreateRoom:
                        if (_server.RoomManager.CreateRoom(msg.Content))
                            _server.Log($"CREATE ROOM — {User.Username} tạo #{msg.Content}"); // ← Thêm dấu ;
                        break;

                    case MessageType.GetRooms:
                        await _server.SendRoomListAsync(this);
                        break;
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