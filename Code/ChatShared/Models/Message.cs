using ChatShared.Protocol;
using System.Text.Json;

namespace ChatShared.Models;

public class Message
{
    public MessageType Type { get; set; }

    public string Username { get; set; } = "";

    public string Room { get; set; } = "";

    public string Content { get; set; } = "";

    public DateTime Time { get; set; } = DateTime.Now;

    public Message()
    {

    }

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

    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public static Message FromJson(string json)
    {
        return JsonSerializer.Deserialize<Message>(json)!;
    }
}