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
        CreateRoom("general");
        CreateRoom("random");
        CreateRoom("gaming");
    }

    public bool CreateRoom(string roomName)
    {
        var room = new Room { RoomName = roomName, CreatedAt = DateTime.Now };
        return _rooms.TryAdd(roomName, room);
    }

    public bool RoomExists(string roomName) => _rooms.ContainsKey(roomName);

    public List<Room> GetAllRooms() => _rooms.Values.ToList();

    public Room? GetRoom(string roomName) =>
        _rooms.TryGetValue(roomName, out var room) ? room : null;

    public bool DeleteRoom(string roomName) =>
        _rooms.TryRemove(roomName, out _);
}