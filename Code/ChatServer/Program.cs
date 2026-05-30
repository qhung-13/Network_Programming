using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
class Server
{
    static TcpListener? server;

    static List<TcpClient> clients = new List<TcpClient>();

    static Dictionary<TcpClient, string> usernames = new Dictionary<TcpClient, string>();
    static void Main()
    {
        server = new TcpListener(IPAddress.Any, 5000);

        server.Start();

        Console.WriteLine("Server started...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();

            clients.Add(client);

            Broadcast("SYSTEM| A user joined the chat\n");
            
            Console.WriteLine("New client connected!");

            Thread clientThread = new Thread(() => HandleClient(client));

            Console.OutputEncoding = Encoding.UTF8;

            clientThread.Start();
        }
    }

    static void HandleClient(TcpClient client)
    {
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];

        while (true)
        {
            int byteCount = stream.Read(buffer, 0, buffer.Length);

            if (byteCount == 0)
                {
                    string username = usernames[client];

                    clients.Remove(client);

                    usernames.Remove(client);

                    Broadcast("SYSTEM|" + username + " left the chat");
                    
                    File.AppendAllText(
                    "log.txt",
                    username + " left" + Environment.NewLine
                     );
                Console.WriteLine(username + " left the chat");

                    break;
                }
            

            string msg = Encoding.UTF8.GetString(buffer, 0, byteCount);


            Console.WriteLine("RAW: " + msg);

            string[] parts = msg.Split('|');

            string type = parts[0];

            if (type == "JOIN")
            {

                string username = parts[1];

                usernames[client] = username;

                Console.WriteLine(username + " joined");

                File.AppendAllText(
                   "log.txt",
                   username + " joined" + Environment.NewLine
                 );

                Broadcast("SYSTEM|" + username + " joined the chat");

                continue;
            }
            if (type == "CHAT")
            {
                string username = parts[1];

                string content = parts[2];

                Console.WriteLine(username + ": " + content);
                
                File.AppendAllText(
                  "log.txt",
                  username + ": " + content + Environment.NewLine
                 );

                Console.WriteLine("Client says: " + msg);

                Broadcast(msg);
            }
        }
    }

    static void Broadcast(string msg)
    {
        byte[] data = Encoding.UTF8.GetBytes(msg + "\n");

        foreach (TcpClient client in clients)
        {
            NetworkStream stream = client.GetStream();

            stream.Write(data, 0, data.Length);
        }
    }
}