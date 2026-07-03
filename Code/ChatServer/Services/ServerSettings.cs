namespace ChatServer.Services;

/// <summary>
/// Represents the configuration model for the chat server.
/// Stores network parameters and logging preferences.
/// </summary>
internal class ServerSettings
{
    #region Network Configuration

    /// <summary>
    /// The network port the TCP server will listen on.
    /// </summary>
    public int Port { get; set; } = 8080;

    /// <summary>
    /// The maximum number of concurrent client connections allowed.
    /// </summary>
    public int MaxClients { get; set; } = 65;

    #endregion

    #region Logging Configuration

    /// <summary>
    /// Determines whether the server should write operational logs to a file.
    /// </summary>
    public bool EnableLogging { get; set; } = true;

    /// <summary>
    /// The absolute or relative path to the server's log file.
    /// </summary>
    public string LogFilePath { get; set; } = "";

    #endregion
}