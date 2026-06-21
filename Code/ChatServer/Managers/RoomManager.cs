using System.Collections.Concurrent;
using ChatShared.Models;

namespace ChatServer.Managers;

public class RoomManager
{
    // Danh sách phòng: roomName -> Room
    private readonly ConcurrentDictionary<string, Room> _rooms = new();

    public RoomManager()
    {
        // Tạo sẵn 3 phòng mặc định
        CreateRoom(new Room { RoomName = "general", Description = "General chat" });
        CreateRoom(new Room { RoomName = "random", Description = "Random chat" });
        CreateRoom(new Room { RoomName = "gaming", Description = "Gaming chat" });
        CreateRoom(new Room { RoomName = "study", Description = "Study chat" });
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

    public Room? GetRoom(string roomName) =>
        _rooms.TryGetValue(roomName, out var room) ? room : null;

    public bool DeleteRoom(string roomName) =>
        _rooms.TryRemove(roomName, out _);
}