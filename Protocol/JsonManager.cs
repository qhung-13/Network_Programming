using Newtonsoft.Json;
using ChatShared.Models;

namespace ChatShared.Protocol;

public class JsonManager
{
    public static string Serialize(Message message)
    {
        return JsonConvert.SerializeObject(message);
    }

    public static Message? Deserialize(string json)
    {
        return JsonConvert.DeserializeObject<Message>(json);
    }
}