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

            // Bước 1: Đọc message đầu tiên — phải là type "join"
            var firstLine = await _reader.ReadLineAsync(ct);
            if (firstLine == null) return;

            var joinMsg = Message.FromJson(firstLine);
            if (joinMsg == null || joinMsg.Type != MessageType.Join) return;

            // Lưu thông tin user
            User.Username = joinMsg.Username;
            User.CurrentRoom = joinMsg.Room;

            // Đăng ký client vào danh sách server
            _server.Clients[User.Username] = this;
            _server.Log($"JOIN — {User.Username} → #{User.CurrentRoom}");
            _server.NotifyClientChanged(User.Username, true);

            // Thông báo cho cả phòng có người mới vào
            await _server.BroadcastToRoomAsync(new Message
            {
                Type = MessageType.Join,
                Username = User.Username,
                Room = User.CurrentRoom,
                Content = $"{User.Username} đã tham gia phòng"
            }, User.CurrentRoom);

            // Bước 2: Vòng lặp đọc message liên tục
            string? line;
            while ((line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg == null) continue;

                _server.Log($"MSG — {User.Username} → #{msg.Room}: \"{msg.Content}\"");

                // Broadcast tới tất cả người trong phòng
                await _server.BroadcastToRoomAsync(msg, msg.Room);
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