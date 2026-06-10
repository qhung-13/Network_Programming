using System;

namespace ChatShared
{
    public static class EmojiHelper
    {
        public static string Parse(string msg)
        {
            if (string.IsNullOrEmpty(msg)) return msg;

            // Thay thế các ký tự gõ nhanh thành Emoji trực quan
            msg = msg.Replace(":)", "😊");
            msg = msg.Replace(":(", "😭");
            msg = msg.Replace(":D", "😁");
            msg = msg.Replace("<3", "❤️");
            msg = msg.Replace(";)", "😉");

            return msg;
        }
    }
}