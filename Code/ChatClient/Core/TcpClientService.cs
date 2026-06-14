using System.Net.Sockets;
using ChatShared.Models;
using Message = ChatShared.Models.Message;
using ChatShared.Protocol;

namespace ChatClient.Core;

public class TcpClientService
{
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;
    private CancellationTokenSource _cts = new();

    public bool IsConnected => _client?.Connected ?? false;

    // Events để ChatForm cập nhật UI
    public event Action<Message>? OnMessageReceived;
    public event Action<string>? OnError;
    public event Action? OnDisconnected;

    public async Task<bool> ConnectAsync(string ip, int port, string username, string room)
    {
        try
        {
            Disconnect();

            _client = new TcpClient();
            await _client.ConnectAsync(ip, port);

            var stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };

            // Gửi message join đầu tiên để đăng ký với server
            var joinMsg = new Message
            {
                Type = MessageType.Join,
                Username = username,
                Room = room
            };
            await _writer.WriteLineAsync(joinMsg.ToJson());

            // Bắt đầu lắng nghe message từ server (chạy ngầm)
            _cts = new CancellationTokenSource();
            _ = Task.Run(() => ListenAsync(_cts.Token));

            return true;
        }
        catch (Exception ex)
        {
            OnError?.Invoke($"Không thể kết nối: {ex.Message}");
            return false;
        }
    }

    private async Task ListenAsync(CancellationToken ct)
    {
        try
        {
            string? line;
            while (_reader != null && !ct.IsCancellationRequested && (line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg != null)
                {
                    OnMessageReceived?.Invoke(msg);
                }
            }
            //while ((line = await _reader!.ReadLineAsync(ct)) != null)
            //{
            //    var msg = Message.FromJson(line);
            //    if (msg != null)
            //        OnMessageReceived?.Invoke(msg);
            //}
        }
        catch (Exception ex) when (ex is OperationCanceledException || ex is IOException || ex is ObjectDisposedException)
        {

        } 
        catch (Exception ex)
        {
            OnError?.Invoke($"Lỗi đọc dữ liệu: {ex.Message}");
        }
        finally
        {
            Disconnect();
            OnDisconnected?.Invoke();
        }
        //catch (OperationCanceledException) { }
        //catch (Exception ex)
        //{
        //    OnError?.Invoke($"Mất kết nối: {ex.Message}");
        //}
        //finally
        //{
        //    OnDisconnected?.Invoke();
        //}
    }

    public async Task SendMessageAsync(string username, string room, string content)
    {
        if (_writer == null || !IsConnected) return;

        var msg = new Message
        {
            Type = MessageType.Chat,
            Username = username,
            Room = room,
            Content = content,
            Time = DateTime.Now
        };

        await SendMessageDirectAsync(msg);
    }

    public async Task JoinRoomAsync(string username, string room)
    {
        if (_writer == null || !IsConnected) return;
        var msg = new Message
        {
            Type = MessageType.Join,
            Username = username,
            Room = room
        };
        await _writer.WriteLineAsync(msg.ToJson());
    }

    public async Task SendMessageDirectAsync(Message message)
    {
        if(_writer == null || !IsConnected)
        {
            return;
        }

        try
        {
            await _writer.WriteLineAsync(message.ToJson());
        } 
        catch (Exception ex)
        {
            OnError?.Invoke($"Lỗi khi gửi tin nhắn: {ex.Message}");
            Disconnect();
        }
    }

    public void Disconnect()
    {
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
        }

        _writer?.Close();
        _reader?.Close();
        _client?.Close();

        _writer = null;
        _reader = null;
        _client = null;
    }
}