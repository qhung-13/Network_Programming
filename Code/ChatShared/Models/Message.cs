using ChatShared.Protocol;

namespace ChatShared.Models;

public class Message
{
    public MessageType Type { get; set; }

    public string Username { get; set; }

    public string Room { get; set; }

    public string Content { get; set; }

    public DateTime Time { get; set; }

    // Constructor
    public Message(
        MessageType type,
        string username,
        string room,
        string content)
    {
        Type = type;
        Username = username;
        Room = room;
        Content = content;
        Time = DateTime.Now;
    }
}