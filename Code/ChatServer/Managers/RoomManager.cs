using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using ChatShared.Models;
using ChatMessage = ChatShared.Models.Message;

namespace ChatServer.Managers;

/// <summary>
/// Thread-safe manager for chat rooms and their respective message histories.
/// Handles room creation, capacity validation, and history tracking.
/// </summary>
public class RoomManager
{
    #region Fields & Locks

    // ConcurrentDictionary ensures thread-safe reads and updates for the room registry
    private readonly ConcurrentDictionary<string, Room> _rooms = new();

    // Maps a normalized room name to its message history
    private readonly ConcurrentDictionary<string, List<ChatMessage>> _roomMessages = new();

    // Object used to synchronize access to the non-thread-safe List<ChatMessage> 
    // to prevent race conditions during concurrent message additions or reads.
    private readonly object _historyLock = new();

    #endregion

    #region Constructor

    public RoomManager()
    {
        // Seed the server with default system rooms upon initialization
        CreateRoom(new Room { RoomName = "general", Description = "General chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "random", Description = "Random chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "gaming", Description = "Gaming chat", MaxMembers = 0 });
        CreateRoom(new Room { RoomName = "study", Description = "Study chat", MaxMembers = 0 });
    }

    #endregion

    #region Room Lifecycle Management

    /// <summary>
    /// Creates a new room with a default configuration (unlimited members).
    /// </summary>
    public bool CreateRoom(string roomName)
    {
        return CreateRoom(new Room
        {
            RoomName = roomName,
            MaxMembers = 0
        });
    }

    /// <summary>
    /// Core method to register a new room into the server registry.
    /// </summary>
    public bool CreateRoom(Room room)
    {
        string roomName = NormalizeRoomName(room.RoomName);

        if (string.IsNullOrWhiteSpace(roomName))
        {
            return false;
        }

        // Fallback for invalid capacity inputs (0 indicates unlimited capacity)
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

        // Cascade delete: Safely remove the room's message history alongside the room itself
        _roomMessages.TryRemove(roomName, out _);

        return _rooms.TryRemove(roomName, out _);
    }

    #endregion

    #region Validation & Operations

    /// <summary>
    /// Evaluates whether a user is permitted to join a target room based on its capacity limits.
    /// </summary>
    public bool CanJoinRoom(string roomName, int currentMemberCount, out string errorMessage)
    {
        errorMessage = "";

        Room? room = GetRoom(roomName);

        if (room == null)
        {
            errorMessage = $"Phòng #{NormalizeRoomName(roomName)} không tồn tại.";
            return false;
        }

        // MaxMembers == 0 signifies unlimited capacity. 
        // If > 0, strictly enforce the ceiling limit.
        if (room.MaxMembers > 0 && currentMemberCount >= room.MaxMembers)
        {
            errorMessage = $"Phòng #{room.RoomName} đã đủ thành viên ({currentMemberCount}/{room.MaxMembers}).";
            return false;
        }

        return true;
    }

    #endregion

    #region Message History Tracking

    /// <summary>
    /// Appends a new message to a room's history in a thread-safe manner.
    /// Automatically creates the room if it does not already exist.
    /// </summary>
    public void AddMessage(ChatMessage message)
    {
        string roomName = NormalizeRoomName(message.Room);

        if (!_rooms.ContainsKey(roomName))
        {
            CreateRoom(roomName);
        }

        message.Room = roomName;

        // Enforce exclusive thread access when modifying the List instance
        lock (_historyLock)
        {
            if (!_roomMessages.ContainsKey(roomName))
            {
                _roomMessages[roomName] = new List<ChatMessage>();
            }

            _roomMessages[roomName].Add(message);
        }
    }

    /// <summary>
    /// Safely retrieves and chronologically sorts the message history for a specific room.
    /// </summary>
    public List<ChatMessage> GetMessages(string roomName)
    {
        roomName = NormalizeRoomName(roomName);

        // Enforce exclusive thread access when reading the List instance to prevent concurrent modification exceptions
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

    #endregion

    #region Utilities

    /// <summary>
    /// Standardizes room names for consistent routing and dictionary lookups.
    /// Removes leading hashtags and converts to lowercase.
    /// </summary>
    private string NormalizeRoomName(string roomName)
    {
        return roomName.Trim().TrimStart('#').ToLower();
    }

    #endregion
}