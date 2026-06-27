using System.Collections.Concurrent;
using ChatShared.Models;
using ChatMessage = ChatShared.Models.Message;

namespace ChatServer.Managers;

public class RoomManager
{
    // Danh sách phòng: roomName -> Room
    private readonly ConcurrentDictionary<string, Room> _rooms = new();
    private readonly ConcurrentDictionary<string, List<ChatMessage>> _roomMessages = new();
    private readonly object _historyLock = new();

    public RoomManager()
    {
        // Tạo sẵn 3 phòng mặc định
        CreateRoom(new Room { RoomName = "general", Description = "General chat" });
        CreateRoom(new Room { RoomName = "random", Description = "Random chat" });
        CreateRoom(new Room { RoomName = "gaming", Description = "Gaming chat" });
        CreateRoom(new Room { RoomName = "study", Description = "Study chat" });
    }
    
    private string NormalizeRoomName(string roomName)
    {
        return roomName.Trim().TrimStart('#').ToLower();
    }

    public bool CreateRoom(string roomName)
    {
        return CreateRoom(new Room
        {
            RoomName = roomName
        });
    }

    public bool CreateRoom(Room room)
    {
        room.RoomName = room.RoomName.Trim().TrimStart('#').ToLower();

        if (string.IsNullOrWhiteSpace(room.RoomName))
            return false;

        return _rooms.TryAdd(room.RoomName, room);
    }

    public bool RoomExists(string roomName)
    {
        roomName = roomName.Trim().TrimStart('#').ToLower();
        return _rooms.ContainsKey(roomName);
    }

    public List<Room> GetAllRooms()
    {
        return _rooms.Values
            .OrderBy(r => r.CreatedAt)
            .ToList();
    }

    public Room? GetRoom(string roomName)
    {
        roomName = NormalizeRoomName(roomName);
        return _rooms.TryGetValue(roomName, out var room) ? room : null;
    }

    public bool DeleteRoom(string roomName)
    {
        roomName = NormalizeRoomName(roomName);
        _roomMessages.TryRemove(roomName, out _);
        return _rooms.TryRemove(roomName, out _);
    }

    public void AddMessage(ChatMessage message)
    {
        var roomName = NormalizeRoomName(message.Room);

        if (!_rooms.ContainsKey(roomName))
            CreateRoom(roomName);

        message.Room = roomName;

        lock (_historyLock)
        {
            if (!_roomMessages.ContainsKey(roomName))
                _roomMessages[roomName] = new List<ChatMessage>();

            _roomMessages[roomName].Add(message);
        }
    }

    public List<ChatMessage> GetMessages(string roomName)
    {
        roomName = NormalizeRoomName(roomName);

        lock (_historyLock)
        {
            if (!_roomMessages.TryGetValue(roomName, out var messages))
                return new List<ChatMessage>();

            return messages
                .OrderBy(m => m.Time)
                .ToList();
        }
    }
}