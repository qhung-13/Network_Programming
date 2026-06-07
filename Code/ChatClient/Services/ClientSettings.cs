namespace ChatClient.Services;

public class ClientSettings
{
    public string Username { get; set; } = "";
    public string ServerIP { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 8080;
    public string LastRoom { get; set; } = "general";
    public bool AutoReconnect { get; set; } = true;
    public bool EnableNotifications { get; set; } = true;
    public bool EnableSound { get; set; } = false;
}