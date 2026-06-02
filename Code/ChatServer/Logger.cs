using System;
using System.IO;

public static class Logger
{
    private static string logFile = "server.log";

    public static void Log(string message)
    {
        string log =
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}";

        File.AppendAllText(
            logFile,
            log + Environment.NewLine
        );
    }
}