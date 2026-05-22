using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using ChatShared.Models;
using Message = ChatShared.Models.Message;

namespace ChatServer.Core;

public class TcpServer
{
    private TcpListener _listener;
    private CancellationTokenSource _cts = new();
    private bool _isRunning = false;

    // Lưu tất cả client đang kết nối: username -> ClientHandler
    public ConcurrentDictionary<string, ClientHandler> Clients { get; } = new();

    // Event để ServerForm hiển thị log
    public event Action<string>? OnLog;
    public event Action<string, bool>? OnClientChanged; // username, isConnected

    public TcpServer(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
    }

    public async Task StartAsync()
    {
        if (_isRunning) return;
        _isRunning = true;
        _cts = new CancellationTokenSource();

        _listener.Start();
        Log($"SERVER STARTED — Listening on port {((IPEndPoint)_listener.LocalEndpoint).Port}");

        try
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                // Chờ client kết nối vào
                var tcpClient = await _listener.AcceptTcpClientAsync(_cts.Token);
                Log($"CONNECT — {tcpClient.Client.RemoteEndPoint}");

                // Mỗi client chạy trên 1 task riêng, không block vòng lặp
                var handler = new ClientHandler(tcpClient, this);
                _ = Task.Run(() => handler.HandleAsync(_cts.Token));
            }
        }
        catch (OperationCanceledException)
        {
            // Server bị stop, bình thường
        }
        finally
        {
            _listener.Stop();
            _isRunning = false;
            Log("SERVER STOPPED");
        }
    }

    public void Stop()
    {
        _cts.Cancel();
    }

    // Gửi message đến TẤT CẢ client trong 1 phòng
    public async Task BroadcastToRoomAsync(Message message, string room)
    {
        var targets = Clients.Values.Where(c => c.User.CurrentRoom == room);
        var tasks = targets.Select(c => c.SendMessageAsync(message));
        await Task.WhenAll(tasks);
    }

    // Gửi message đến TẤT CẢ client
    public async Task BroadcastToAllAsync(Message message)
    {
        var tasks = Clients.Values.Select(c => c.SendMessageAsync(message));
        await Task.WhenAll(tasks);
    }

    public void Log(string message)
    {
        var log = $"[{DateTime.Now:HH:mm:ss}] {message}";
        OnLog?.Invoke(log);
    }

    public void NotifyClientChanged(string username, bool isConnected)
    {
        OnClientChanged?.Invoke(username, isConnected);
    }
}