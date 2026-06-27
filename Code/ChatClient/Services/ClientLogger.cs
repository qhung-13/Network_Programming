using System;
using System.IO;

namespace ChatClient.Services;

public static class ClientLogger
{
    private static readonly object _lock = new();

    public static string GetLogPath()
    {
        string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        if (!Directory.Exists(logDir))
            Directory.CreateDirectory(logDir);

        return Path.Combine(logDir, "client.log");
    }

    public static void Log(string message)
    {
        try
        {
            string logPath = GetLogPath();

            string line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

            lock (_lock)
            {
                File.AppendAllText(logPath, line + Environment.NewLine);
            }
        }
        catch
        {
    
        }
    }

    public static void Clear()
    {
        try
        {
            string logPath = GetLogPath();

            lock (_lock)
            {
                File.WriteAllText(logPath, "");
            }
        }
        catch
        {
        }
    }
}