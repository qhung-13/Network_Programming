using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChatShared.Models;

namespace ChatServer.Managers;

/// <summary>
/// Thread-safe manager responsible for tracking active users across the server.
/// Handles user registration, room assignments, and profile updates.
/// </summary>
public class UserManager
{
    #region Fields

    // Utilizes a ConcurrentDictionary to ensure thread-safe operations 
    // without requiring explicit locking when users connect, disconnect, or chat concurrently.
    private readonly ConcurrentDictionary<string, User> _users = new();

    #endregion

    #region Core Operations

    /// <summary>
    /// Registers a new user into the active session pool.
    /// </summary>
    /// <returns>True if the user was successfully added; False if the username already exists.</returns>
    public bool AddUser(User user) => _users.TryAdd(user.Username, user);

    /// <summary>
    /// Safely removes a user from the active session pool upon disconnection.
    /// </summary>
    public bool RemoveUser(string username) => _users.TryRemove(username, out _);

    #endregion

    #region Queries

    /// <summary>
    /// Retrieves a user instance by their unique username.
    /// </summary>
    public User? GetUser(string username) =>
        _users.TryGetValue(username, out var user) ? user : null;

    /// <summary>
    /// Returns a snapshot list of all currently active users on the server.
    /// </summary>
    public List<User> GetAllUsers() => _users.Values.ToList();

    /// <summary>
    /// Filters and returns a snapshot list of users currently occupying a specific room.
    /// </summary>
    public List<User> GetUsersInRoom(string roomName) =>
        _users.Values.Where(u => u.CurrentRoom == roomName).ToList();

    #endregion

    #region State Updates

    /// <summary>
    /// Updates the routing state of a user when they transition between rooms.
    /// </summary>
    public bool ChangeRoom(string username, string newRoom)
    {
        var user = GetUser(username);

        if (user == null) return false;

        user.CurrentRoom = newRoom;
        return true;
    }

    /// <summary>
    /// Safely updates a user's display name without dropping their network session.
    /// </summary>
    public bool UpdateDisplayName(string username, string newDisplayName)
    {
        var user = GetUser(username);

        if (user == null)
        {
            return false;
        }

        user.DisplayName = newDisplayName.Trim();
        return true;
    }

    #endregion
}