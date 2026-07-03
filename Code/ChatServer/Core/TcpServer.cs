using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ChatServer.Managers;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;

namespace ChatServer.Core;

/// <summary>
/// Core TCP server implementation. 
/// Manages incoming connections, tracks active clients, and acts as the central hub for message broadcasting.
/// </summary>
public class TcpServer
{
    #region Fields & Properties

    private TcpListener _listener;
    private CancellationTokenSource _cts = new();
    private bool _isRunning = false;

    /// <summary>
    /// Thread-safe dictionary tracking all active connections.
    /// Key: Username -> Value: ClientHandler instance.
    /// </summary>
    public ConcurrentDictionary<string, ClientHandler> Clients { get; } = new();

    public RoomManager RoomManager { get; } = new();
    public UserManager UserManager { get; } = new();

    #endregion

    #region Events

    // Events exposed for the UI (e.g., ServerForm) to display real-time metrics and logs
    public event Action<string>? OnLog;

    // Triggered when a user joins or leaves (username, isConnected)
    public event Action<string, bool>? OnClientChanged;

    #endregion

    #region Constructor & Lifecycle

    public TcpServer(int port)
    {
        // Bind the server to all available network interfaces on the specified port
        _listener = new TcpListener(IPAddress.Any, port);
    }

    /// <summary>
    /// Starts the TCP listener and enters the main connection acceptance loop.
    /// </summary>
    public async Task StartAsync()
    {
        if (_isRunning) return;

        _isRunning = true;
        _cts = new CancellationTokenSource();

        _listener.Start();
        Log($"SERVER STARTED — Listening on port {((IPEndPoint)_listener.LocalEndpoint).Port}");

        try
        {
            // Continuously listen for new client connections until a cancellation is requested
            while (!_cts.Token.IsCancellationRequested)
            {
                // Await incoming connection (non-blocking)
                var tcpClient = await _listener.AcceptTcpClientAsync(_cts.Token);
                Log($"CONNECT — {tcpClient.Client.RemoteEndPoint}");

                // Delegate the specific client session to a new handler instance
                var handler = new ClientHandler(tcpClient, this);

                // Fire-and-forget task: Process the client concurrently without blocking the acceptance loop
                _ = Task.Run(() => handler.HandleAsync(_cts.Token));
            }
        }
        catch (OperationCanceledException)
        {
            // Expected behavior when Stop() is called and the cancellation token is triggered
        }
        finally
        {
            // Ensure the listener is properly torn down
            _listener.Stop();
            _isRunning = false;
            Log("SERVER STOPPED");
        }
    }

    /// <summary>
    /// Signals the server to stop accepting new connections and shuts down the listener.
    /// </summary>
    public void Stop()
    {
        _cts.Cancel();
    }

    #endregion

    #region Broadcasting & Messaging

    /// <summary>
    /// Dispatches a message to all active clients currently residing in the specified room.
    /// </summary>
    public async Task BroadcastToRoomAsync(Message message, string room)
    {
        // Filter clients based on their current room state
        var targets = Clients.Values.Where(c => c.User.CurrentRoom == room);

        // Execute dispatch tasks concurrently
        var tasks = targets.Select(c => c.SendMessageAsync(message));
        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Dispatches a message globally to every connected client on the server.
    /// </summary>
    public async Task BroadcastToAllAsync(Message message)
    {
        var tasks = Clients.Values.Select(c => c.SendMessageAsync(message));
        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Sends the current list of available rooms to a specific client.
    /// </summary>
    public async Task SendRoomListAsync(ClientHandler client)
    {
        var rooms = RoomManager.GetAllRooms();
        var msg = new Message
        {
            Type = MessageType.GetRooms,
            Content = JsonSerializer.Serialize(rooms)
        };

        await client.SendMessageAsync(msg);
    }

    /// <summary>
    /// Broadcasts the updated room list to all connected clients.
    /// </summary>
    public async Task BroadcastRoomListAsync()
    {
        var rooms = RoomManager.GetAllRooms();
        var msg = new Message
        {
            Type = MessageType.GetRooms,
            Content = JsonSerializer.Serialize(rooms)
        };

        await BroadcastToAllAsync(msg);
    }

    /// <summary>
    /// Broadcasts the latest roster of active users in a specific room to all members of that room.
    /// </summary>
    public async Task BroadcastRoomUsersAsync(string roomName)
    {
        // Sanitize the room routing key
        roomName = roomName.Trim().TrimStart('#').ToLower();

        // Project necessary user data to minimize payload size
        var users = UserManager.GetUsersInRoom(roomName)
            .Select(u => new User
            {
                Username = u.Username,
                DisplayName = u.DisplayName,
                CurrentRoom = u.CurrentRoom,
                IsOnline = u.IsOnline,
                JoinedAt = u.JoinedAt
            })
            .ToList();

        var msg = new Message
        {
            Type = MessageType.RoomUsers,
            Room = roomName,
            Content = JsonSerializer.Serialize(users)
        };

        await BroadcastToRoomAsync(msg, roomName);
    }

    /// <summary>
    /// Sends historical chat messages of a specific room to a newly joined client.
    /// </summary>
    public async Task SendRoomHistoryAsync(ClientHandler client, string roomName)
    {
        roomName = roomName.Trim().TrimStart('#').ToLower();
        var history = RoomManager.GetMessages(roomName);

        var msg = new Message
        {
            Type = MessageType.RoomHistory,
            Room = roomName,
            Content = JsonSerializer.Serialize(history)
        };

        await client.SendMessageAsync(msg);
    }

    #endregion

    #region System Helpers

    /// <summary>
    /// Formats and dispatches an internal server log entry to the presentation layer.
    /// </summary>
    public void Log(string message)
    {
        var log = $"[{DateTime.Now:HH:mm:ss}] {message}";
        OnLog?.Invoke(log);
    }

    /// <summary>
    /// Notifies the server UI when a client connection state changes.
    /// </summary>
    public void NotifyClientChanged(string username, bool isConnected)
    {
        OnClientChanged?.Invoke(username, isConnected);
    }

    #endregion
}