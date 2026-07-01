using System.Collections.Concurrent;
using ChatShared.Models;
using ChatMessage = ChatShared.Models.Message;

namespace ChatServer.Managers;

public class RoomManager
{
    private readonly ConcurrentDictionary<string, Room> _rooms = new();
    private readonly ConcurrentDictionary<string, List<ChatMessage>> _roomMessages = new();
    private readonly object _historyLock = new();

    public RoomManager()
    {
        CreateRoom(new Room { RoomName = "general", Description = "General chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "random", Description = "Random chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "gaming", Description = "Gaming chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "study", Description = "Study chat", MaxMembers = 0 });
    }

    public bool CreateRoom(string roomName)
    {
        return CreateRoom(new Room
        {
            RoomName = roomName,
            MaxMembers = 0
        });
    }

    public bool CreateRoom(Room room)
    {
        string roomName = NormalizeRoomName(room.RoomName);

        if (string.IsNullOrWhiteSpace(roomName))
        {
            return false;
        }

        if (room.MaxMembers < 0)
        {
            room.MaxMembers = 0;
        }

        room.RoomName = roomName;
        room.CreatedAt = room.CreatedAt == default ? DateTime.Now : room.CreatedAt;

        return _rooms.TryAdd(room.RoomName, room);
    }

    public bool RoomExists(string roomName)
    {
        roomName = NormalizeRoomName(roomName);
        return _rooms.ContainsKey(roomName);
    }

    public Room? GetRoom(string roomName)
    {
        roomName = NormalizeRoomName(roomName);
        return _rooms.TryGetValue(roomName, out Room? room) ? room : null;
    }

    public List<Room> GetAllRooms()
    {
        return _rooms.Values
            .OrderBy(room => room.CreatedAt)
            .ToList();
    }

    public bool DeleteRoom(string roomName)
    {
        roomName = NormalizeRoomName(roomName);

        _roomMessages.TryRemove(roomName, out _);

        return _rooms.TryRemove(roomName, out _);
    }

    public bool CanJoinRoom(string roomName, int currentMemberCount, out string errorMessage)
    {
        errorMessage = "";

        Room? room = GetRoom(roomName);

        if (room == null)
        {
            errorMessage = $"Phòng #{NormalizeRoomName(roomName)} không tồn tại.";
            return false;
        }

        if (room.MaxMembers > 0 && currentMemberCount >= room.MaxMembers)
        {
            errorMessage = $"Phòng #{room.RoomName} đã đủ thành viên ({currentMemberCount}/{room.MaxMembers}).";
            return false;
        }

        return true;
    }

    public void AddMessage(ChatMessage message)
    {
        string roomName = NormalizeRoomName(message.Room);

        if (!_rooms.ContainsKey(roomName))
        {
            CreateRoom(roomName);
        }

        message.Room = roomName;

        lock (_historyLock)
        {
            if (!_roomMessages.ContainsKey(roomName))
            {
                _roomMessages[roomName] = new List<ChatMessage>();
            }

            _roomMessages[roomName].Add(message);
        }
    }

    public List<ChatMessage> GetMessages(string roomName)
    {
        roomName = NormalizeRoomName(roomName);

        lock (_historyLock)
        {
            if (!_roomMessages.TryGetValue(roomName, out List<ChatMessage>? messages))
            {
                return new List<ChatMessage>();
            }

            return messages
                .OrderBy(message => message.Time)
                .ToList();
        }
    }

    private string NormalizeRoomName(string roomName)
    {
        return roomName.Trim().TrimStart('#').ToLower();
    }
}