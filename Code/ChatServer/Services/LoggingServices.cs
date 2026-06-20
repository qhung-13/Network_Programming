using System;
using System.IO;

namespace ChatServer.Services;

public static class Logger
{
    private static readonly string logFile = GetLogFilePath();

    private static string GetLogFilePath()
    {
        var currentDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

        while (currentDir != null)
        {
            string chatSharedPath = Path.Combine(currentDir.FullName, "ChatShared");

            if (Directory.Exists(chatSharedPath))
            {
                string logFolder = Path.Combine(chatSharedPath, "Log");

                if (!Directory.Exists(logFolder))
                {
                    Directory.CreateDirectory(logFolder);
                }

                return Path.Combine(logFolder, "server.log");
            }

            currentDir = currentDir.Parent;
        }

        string fallbackFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");

        if (!Directory.Exists(fallbackFolder))
        {
            Directory.CreateDirectory(fallbackFolder);
        }

        return Path.Combine(fallbackFolder, "server.log");
    }

    public static void Log(string message)
    {
        string log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

        File.AppendAllText(
            logFile,
            log + Environment.NewLine
        );
    }
}