using System;
using System.IO;
using System.Text;

namespace ChatServer.Services;

public static class Logger
{
    private static readonly object _lock = new();

    private static string _logFilePath = GetDefaultLogFilePath();

    public static bool IsEnabled { get; private set; } = true;

    public static string LogFilePath => _logFilePath;

    public static void Configure(string logPath, bool isEnabled)
    {
        IsEnabled = isEnabled;

        if (string.IsNullOrWhiteSpace(logPath))
        {
            return;
        }

        string finalPath = ResolveLogPath(logPath);

        string? folder = Path.GetDirectoryName(finalPath);

        if (!string.IsNullOrWhiteSpace(folder))
        {
            Directory.CreateDirectory(folder);
        }

        _logFilePath = finalPath;
    }

    public static void Log(string message)
    {
        if (!IsEnabled)
        {
            return;
        }

        string logLine = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

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

    public static void ExportTo(string destinationPath)
    {
        if (string.IsNullOrWhiteSpace(destinationPath))
        {
            throw new ArgumentException("Destination path is empty.");
        }

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

    private static string ResolveLogPath(string path)
    {
        string trimmedPath = path.Trim();

        if (Path.IsPathRooted(trimmedPath))
        {
            return trimmedPath;
        }

        return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, trimmedPath);
    }

    private static string GetDefaultLogFilePath()
    {
        DirectoryInfo? currentDir = new(AppDomain.CurrentDomain.BaseDirectory);

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

        string fallbackFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        Directory.CreateDirectory(fallbackFolder);

        return Path.Combine(fallbackFolder, "server.log");
    }
}