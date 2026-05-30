
using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;

class Client
{
    static string username = "";

    static TcpClient? client;

    static NetworkStream? stream;

    static void Main()
    {
        
        Console.OutputEncoding = Encoding.UTF8;
        
        Console.Write("Enter username: ");

        username = Console.ReadLine()!;

        client = new TcpClient("127.0.0.1", 5000);
        
        stream = client.GetStream();
        
        string joinMsg = "JOIN|" + username;
        
        byte[] joinData = Encoding.UTF8.GetBytes(joinMsg);
        
        stream.Write(joinData, 0, joinData.Length);
        
        Console.WriteLine("Connected to server!"); 

        Thread receiveThread = new Thread(ReceiveMessages);

        receiveThread.Start();

        while (true)
        {
            string? text = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(text))
            {
                Thread.Sleep(100); 
                continue;
            }

            if (text == "/exit")
            {
                client.Close();

                break;
            }

            string msg = "CHAT|" +  username + "|" + text;

            byte[] data = Encoding.UTF8.GetBytes(msg);

            stream!.Write(data, 0, data.Length);
        }
    }

    static void ReceiveMessages()
    {
        byte[] buffer = new byte[1024];

        while (true)
        {
            int byteCount = stream!.Read(buffer, 0, buffer.Length);

            if (byteCount == 0)
            {
                break;
            }

            string msg = Encoding.UTF8.GetString(buffer, 0, byteCount);

            string[] parts = msg.Split('|');

            string type = parts[0];

            if (type == "SYSTEM")
            {
                string content = parts[1];

                Console.WriteLine("[SYSTEM] " + content);
            }
            else if (type == "CHAT")
            {
                string username = parts[1];

                string content = parts[2];

                content = EmojiHelper.Parse(content);

                Console.WriteLine(username + ": " + content);
            }
        }
    }
}