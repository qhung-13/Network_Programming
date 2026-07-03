using System;
using System.IO;

namespace ChatClient.Services;

/// <summary>
/// Provides thread-safe logging capabilities for the client application.
/// Writes timestamped log entries to a local text file.
/// </summary>
public static class ClientLogger
{
    // Synchronization primitive to ensure thread safety during concurrent file I/O operations
    private static readonly object _lock = new();

    /// <summary>
    /// Resolves the absolute path to the log file, ensuring the target directory exists.
    /// </summary>
    /// <returns>The full file path for the client log.</returns>
    public static string GetLogPath()
    {
        // Resolve the base directory where the application is executing
        string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        // Ensure the directory exists before attempting to write files into it
        if (!Directory.Exists(logDir))
        {
            Directory.CreateDirectory(logDir);
        }

        return Path.Combine(logDir, "client.log");
    }

    /// <summary>
    /// Appends a timestamped message to the log file in a thread-safe manner.
    /// </summary>
    /// <param name="message">The message content to be logged.</param>
    public static void Log(string message)
    {
        try
        {
            string logPath = GetLogPath();
            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

            // Lock the file write operation to prevent multiple threads from writing simultaneously
            lock (_lock)
            {
                File.AppendAllText(logPath, line + Environment.NewLine);
            }
        }
        catch
        {
            // Intentionally swallowed exception:
            // We do not want a non-critical logging failure (e.g., file locked by an antivirus 
            // or missing permissions) to crash the entire client application.
        }
    }

    /// <summary>
    /// Clears all contents of the current log file.
    /// </summary>
    public static void Clear()
    {
        try
        {
            string logPath = GetLogPath();

            // Lock the operation to ensure no other thread is writing while the file is being cleared
            lock (_lock)
            {
                File.WriteAllText(logPath, "");
            }
        }
        catch
        {
            // Intentionally swallowed exception to prevent application crashes during log cleanup
        }
    }
}