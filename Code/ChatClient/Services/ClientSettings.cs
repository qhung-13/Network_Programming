namespace ChatClient.Services;

/// <summary>
/// Represents the configuration, preferences, and state data for the chat client.
/// This model is designed to be serialized/deserialized to persist user data across sessions.
/// </summary>
public class ClientSettings
{
    #region Connection & Identity

    /// <summary>
    /// The user's active display name in the chat application.
    /// </summary>
    public string Username { get; set; } = "";

    /// <summary>
    /// The IPv4 or IPv6 address of the target chat server.
    /// </summary>
    public string ServerIP { get; set; } = "127.0.0.1";

    /// <summary>
    /// The network port used to establish the TCP connection.
    /// </summary>
    public int Port { get; set; } = 8080;

    /// <summary>
    /// Tracks the last room the user was active in for session restoration.
    /// </summary>
    public string LastRoom { get; set; } = "general";

    /// <summary>
    /// Determines whether the client should automatically attempt to reconnect upon connection loss.
    /// </summary>
    public bool AutoReconnect { get; set; } = true;

    #endregion

    #region Notification Preferences

    public bool EnableNotifications { get; set; } = true;
    public bool EnableSound { get; set; } = false;
    public bool EnableMentionNotifications { get; set; } = true;
    public bool EnableRoomJoinLeaveNotifications { get; set; } = true;
    public bool EnableNewRoomNotifications { get; set; } = true;
    public bool EnableDisconnectNotifications { get; set; } = true;

    #endregion

    #region Analytics & Statistics

    /// <summary>
    /// Lifetime count of messages dispatched by the user.
    /// </summary>
    public int MessagesSent { get; set; } = 0;

    /// <summary>
    /// Lifetime count of unique rooms the user has successfully joined.
    /// </summary>
    public int RoomsJoined { get; set; } = 0;

    /// <summary>
    /// Cumulative active session time measured in seconds.
    /// </summary>
    public long TotalOnlineSeconds { get; set; } = 0;

    #endregion
}