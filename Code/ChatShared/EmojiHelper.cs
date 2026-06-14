namespace ChatShared;

public static class EmojiHelper
{
    public static string Parse(string msg)
    {
        if (string.IsNullOrEmpty(msg)) return msg;

        msg = msg.Replace(":)", "😊");
        msg = msg.Replace(":(", "😢");
        msg = msg.Replace(":D", "😁");
        msg = msg.Replace(":P", "😛");
        msg = msg.Replace(";)", "😉");
        msg = msg.Replace("<3", "❤️");
        msg = msg.Replace(":o", "😮");
        msg = msg.Replace(":O", "😮");
        msg = msg.Replace("B)", "😎");
        msg = msg.Replace(">:(", "😠");
        msg = msg.Replace(":*", "😘");
        msg = msg.Replace("^^", "😄");
        msg = msg.Replace(":thumbsup:", "👍");
        msg = msg.Replace(":fire:", "🔥");
        msg = msg.Replace(":100:", "💯");

        return msg;
    }
}