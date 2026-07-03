using System;
using System.IO;
using System.Text;

namespace ChatServer.Services;

/// <summary>
/// Thread-safe static logging service for the server application.
/// Handles log file routing, directory creation, and synchronized file writes using UTF-8 encoding.
/// </summary>
public static class Logger
{
    #region Fields & Properties

    // Synchronization primitive to guarantee thread-safe file I/O operations across multiple client sessions
    private static readonly object _lock = new();

    private static string _logFilePath = GetDefaultLogFilePath();

    /// <summary>
    /// Indicates whether logging is currently active.
    /// </summary>
    public static bool IsEnabled { get; private set; } = true;

    /// <summary>
    /// Retrieves the absolute path to the active log file.
    /// </summary>
    public static string LogFilePath => _logFilePath;

    #endregion

    #region Configuration

    /// <summary>
    /// Updates the logging state and dynamically changes the target log file path.
    /// </summary>
    public static void Configure(string logPath, bool isEnabled)
    {
        IsEnabled = isEnabled;

        if (string.IsNullOrWhiteSpace(logPath))
        {
            return;
        }

        string finalPath = ResolveLogPath(logPath);
        string? folder = Path.GetDirectoryName(finalPath);

        // Ensure the target directory exists before assigning the new path
        if (!string.IsNullOrWhiteSpace(folder))
        {
            Directory.CreateDirectory(folder);
        }

        _logFilePath = finalPath;
    }

    #endregion

    #region Core Logging

    /// <summary>
    /// Appends a timestamped message to the log file in a thread-safe manner.
    /// </summary>
    public static void Log(string message)
    {
        if (!IsEnabled)
        {
            return;
        }

        string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

        // Acquire exclusive lock to prevent file corruption from concurrent thread writes
        lock (_lock)
        {
            string? folder = Path.GetDirectoryName(_logFilePath);

            if (!string.IsNullOrWhiteSpace(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.AppendAllText(
                _logFilePath,
                logLine + Environment.NewLine,
                Encoding.UTF8
            );
        }
    }

    #endregion

    #region File Operations

    /// <summary>
    /// Erases the entire contents of the current log file while maintaining thread safety.
    /// </summary>
    public static void Clear()
    {
        lock (_lock)
        {
            string? folder = Path.GetDirectoryName(_logFilePath);

            if (!string.IsNullOrWhiteSpace(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.WriteAllText(_logFilePath, string.Empty, Encoding.UTF8);
        }
    }

    /// <summary>
    /// Safely copies the active log file to a specified external destination path.
    /// </summary>
    public static void ExportTo(string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            throw new ArgumentException("Destination path is empty.");
        }

        // Lock ensures the file isn't being actively written to during the copy operation
        lock (_lock)
        {
            if (!File.Exists(_logFilePath))
            {
                throw new FileNotFoundException("Log file does not exist.", _logFilePath);
            }

            string finalDestinationPath = ResolveLogPath(destinationPath);
            string? folder = Path.GetDirectoryName(finalDestinationPath);

            if (!string.IsNullOrWhiteSpace(folder))
            {
                Directory.CreateDirectory(folder);
            }

            File.Copy(_logFilePath, finalDestinationPath, overwrite: true);
        }
    }

    #endregion

    #region Path Resolution Helpers

    /// <summary>
    /// Determines if the provided path is absolute or relative, returning the fully qualified path.
    /// </summary>
    private static string ResolveLogPath(string path)
    {
        string trimmedPath = path.Trim();

        // Return immediately if it's an absolute path (e.g., C:\Logs\server.log)
        if (Path.IsPathRooted(trimmedPath))
        {
            return trimmedPath;
        }

        // If relative, anchor it to the application's base execution directory
        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, trimmedPath);
    }

    /// <summary>
    /// Scans upward from the current directory to locate the 'ChatShared' project directory.
    /// Falls back to the execution directory if the shared folder is not found.
    /// </summary>
    private static string GetDefaultLogFilePath()
    {
        DirectoryInfo? currentDir = new(AppDomain.CurrentDomain.BaseDirectory);

        // Traverse parent directories to dynamically find the shared workspace folder
        while (currentDir != null)
        {
            string chatSharedPath = Path.Combine(currentDir.FullName, "ChatShared");

            if (Directory.Exists(chatSharedPath))
            {
                string logFolder = Path.Combine(chatSharedPath, "Log");
                Directory.CreateDirectory(logFolder);

                return Path.Combine(logFolder, "server.log");
            }

            currentDir = currentDir.Parent;
        }

        // Fallback strategy if 'ChatShared' is completely inaccessible
        string fallbackFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        Directory.CreateDirectory(fallbackFolder);

        return Path.Combine(fallbackFolder, "server.log");
    }

    #endregion
}