using System.Collections.Concurrent;
using ChatShared.Models;

namespace ChatServer.Managers;

public class UserManager
{
    private readonly ConcurrentDictionary<string, User> _users = new();

    public bool AddUser(User user) => _users.TryAdd(user.Username, user);

    public bool RemoveUser(string username) => _users.TryRemove(username, out _);

    public User? GetUser(string username) =>
        _users.TryGetValue(username, out var user) ? user : null;

    public List<User> GetAllUsers() => _users.Values.ToList();

    public List<User> GetUsersInRoom(string roomName) =>
        _users.Values.Where(u => u.CurrentRoom == roomName).ToList();

    public bool ChangeRoom(string username, string newRoom)
    {
        var user = GetUser(username);
        if (user == null) return false;
        user.CurrentRoom = newRoom;
        return true;
    }
}