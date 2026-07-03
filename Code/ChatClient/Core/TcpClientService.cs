using System.Net.Sockets;
using System.Text.Json;
using ChatShared.Models;
using ChatShared.Protocol;
using Message = ChatShared.Models.Message;

namespace ChatClient.Core;

/// <summary>
/// Handles TCP communication between the client and the chat server.
/// Manages connection lifecycle, asynchronous message broadcasting, and background listening.
/// </summary>
public class TcpClientService
{
    private TcpClient? _client;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    // Token source used to cleanly cancel the background listening task
    private CancellationTokenSource _cts = new();

    /// <summary>
    /// Indicates whether the underlying TCP client is currently connected.
    /// </summary>
    public bool IsConnected => _client?.Connected ?? false;

    #region UI Synchronization Events

    // Events exposed for the presentation layer (e.g., ChatForm) to update the UI
    public event Action<Message>? OnMessageReceived;
    public event Action<string>? OnError;
    public event Action? OnDisconnected;

    #endregion

    /// <summary>
    /// Establishes a TCP connection to the server and initializes the background listener.
    /// </summary>
    public async Task<bool> ConnectAsync(string ip, int port, string username, string displayname, string room)
    {
        try
        {
            // Ensure any existing connection is properly disposed before initiating a new one
            Disconnect();

            _client = new TcpClient();
            await _client.ConnectAsync(ip, port);

            var stream = _client.GetStream();
            _reader = new StreamReader(stream);

            // AutoFlush ensures data is sent immediately without requiring manual Flush() calls
            _writer = new StreamWriter(stream) { AutoFlush = true };

            // Construct and transmit the initial Join payload to register the client session
            var joinMsg = new Message
            {
                Type = MessageType.Join,
                Username = username,
                DisplayName = displayname,
                Room = room
            };

            await _writer.WriteLineAsync(joinMsg.ToJson());

            // Initialize the cancellation token for the background task
            _cts = new CancellationTokenSource();

            // Fire-and-forget the listener task to continuously monitor incoming traffic 
            // without blocking the main execution thread.
            _ = Task.Run(() => ListenAsync(_cts.Token));

            return true;
        }
        catch (Exception ex)
        {
            OnError?.Invoke($"Không thể kết nối: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Background task that continuously reads incoming stream data from the server.
    /// </summary>
    private async Task ListenAsync(CancellationToken ct)
    {
        try
        {
            string? line;

            // Continuously await new lines from the stream until cancellation is requested 
            // or the connection drops (returns null).
            while (_reader != null && !ct.IsCancellationRequested && (line = await _reader.ReadLineAsync(ct)) != null)
            {
                var msg = Message.FromJson(line);
                if (msg != null)
                {
                    OnMessageReceived?.Invoke(msg);
                }
            }
        }
        // Gracefully swallow expected exceptions that occur during intentional disconnections or stream closures
        catch (Exception ex) when (ex is OperationCanceledException || ex is IOException || ex is ObjectDisposedException)
        {
            // Intentionally left blank: Normal behavior during disconnection
        }
        catch (Exception ex)
        {
            OnError?.Invoke($"Lỗi đọc dữ liệu: {ex.Message}");
        }
        finally
        {
            // Ensure resources are cleaned up and the UI is notified when the listening loop terminates
            Disconnect();
            OnDisconnected?.Invoke();
        }
    }

    /// <summary>
    /// Constructs a standard chat message and dispatches it to the server.
    /// </summary>
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

    /// <summary>
    /// Sends a request to join a specific room.
    /// </summary>
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

    /// <summary>
    /// Core method for transmitting serialized message payloads over the network stream.
    /// </summary>
    public async Task SendMessageDirectAsync(Message message)
    {
        if (_writer == null || !IsConnected)
        {
            return;
        }

        try
        {
            await _writer.WriteLineAsync(message.ToJson());
        }
        catch (Exception ex)
        {
            // If a write operation fails (e.g., broken pipe), notify the UI and tear down the connection
            OnError?.Invoke($"Lỗi khi gửi tin nhắn: {ex.Message}");
            Disconnect();
        }
    }

    /// <summary>
    /// Sends a request to create a new chat room.
    /// </summary>
    public async Task CreateRoomAsync(string username, Room room)
    {
        if (_writer == null || !IsConnected)
        {
            return;
        }

        var msg = new Message
        {
            Type = MessageType.CreateRoom,
            Username = username,
            Room = room.RoomName,
            Content = JsonSerializer.Serialize(room),
            Time = DateTime.Now
        };

        await SendMessageDirectAsync(msg);
    }

    /// <summary>
    /// Requests the server to broadcast the current list of available rooms.
    /// </summary>
    public async Task RequestRoomListAsync()
    {
        if (_writer == null || !IsConnected)
        {
            return;
        }

        var msg = new Message
        {
            Type = MessageType.GetRooms
        };

        await SendMessageDirectAsync(msg);
    }

    /// <summary>
    /// Fetches historical messages for a specific room.
    /// </summary>
    public async Task RequestRoomHistoryAsync(string room)
    {
        if (_writer == null || !IsConnected)
            return;

        var msg = new Message
        {
            Type = MessageType.GetRoomHistory,
            // Ensure room routing keys are sanitized (lowercase and stripped of leading hash)
            Room = room.Trim().TrimStart('#').ToLower()
        };

        await SendMessageDirectAsync(msg);
    }

    /// <summary>
    /// Dispatches a request to update the user's display name globally.
    /// </summary>
    public async Task UpdateDisplayNameAsync(string username, string newDisplayName)
    {
        if (_writer == null || !IsConnected)
        {
            return;
        }

        var msg = new Message
        {
            Type = MessageType.UpdateDisplayName,
            Username = username,
            DisplayName = newDisplayName,
            Content = newDisplayName,
            Time = DateTime.Now,
        };

        await SendMessageDirectAsync(msg);
    }

    /// <summary>
    /// Safely terminates the network connection, cancels background tasks, and releases unmanaged resources.
    /// </summary>
    public void Disconnect()
    {
        // Signal the listening task to terminate cleanly
        if (_cts != null && !_cts.IsCancellationRequested)
        {
            _cts.Cancel();
        }

        // Close underlying streams and connections
        _writer?.Close();
        _reader?.Close();
        _client?.Close();

        // Nullify references to prevent memory leaks and accidental reuse
        _writer = null;
        _reader = null;
        _client = null;
    }
}