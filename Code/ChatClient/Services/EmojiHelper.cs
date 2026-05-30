public class EmojiHelper
{
    public static string Parse(string msg)
    {
        msg = msg.Replace(":)", "😊");

        msg = msg.Replace(":(", "😢");

        msg = msg.Replace(":D", "😆");

        msg = msg.Replace("<3", "❤️");

        return msg;
    }
}