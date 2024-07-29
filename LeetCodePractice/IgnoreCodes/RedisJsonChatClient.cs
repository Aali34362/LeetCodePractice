using System.Net.Sockets;
using System.Text.Json;
using System.Text;

namespace LeetCodePractice.IgnoreCodes;

public class RedisJsonChatClient
{
    public static void RedisJsonChatClientMain()
    {
        Console.Write("Enter server IP: ");
        string serverIp = "127.0.0.1";
        //string serverIp = Console.ReadLine()!;
        // 127.0.0.1:5000

        TcpClient client = new TcpClient(serverIp, 5000);
        NetworkStream stream = client.GetStream();

        ////Thread thread = new Thread(o => ReceiveRedisJsonData((TcpClient)o));
        ////thread.Start(client);

        Console.WriteLine("Connected to chat server.");
        while (true)
        {
            string input = Console.ReadLine()!;
            var command = ParseInputToJson(input);
            if (command == null)
            {
                Console.WriteLine("Invalid command format.");
                continue;
            }

            string message = JsonSerializer.Serialize(command);
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);

            byte[] responseBuffer = new byte[1024];
            int byteCount = stream.Read(responseBuffer, 0, responseBuffer.Length);
            string response = Encoding.ASCII.GetString(responseBuffer, 0, byteCount);
            Console.WriteLine(response);
        }

        ////client.Client.Shutdown(SocketShutdown.Send);
        ////thread.Join();
        ////stream.Close();
        ////client.Close();
    }

    private static Command ParseInputToJson(string input)
    {
        string[] parts = input.Split(' ', 3);

        if (parts.Length < 2) return null;

        return new Command
        {
            Action = parts[0].ToUpper(),
            Key = parts[1],
            Value = parts.Length > 2 ? parts[2] : null
        };
    }

    ////private static void ReceiveRedisJsonData(TcpClient client)
    ////{
    ////    NetworkStream stream = client.GetStream();
    ////    byte[] buffer = new byte[1024];
    ////    int byteCount;

    ////    while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
    ////    {
    ////        Console.WriteLine("Server response: " + Encoding.ASCII.GetString(buffer, 0, byteCount));
    ////    }
    ////}
}
public class Command
{
    public string? Action { get; set; }
    public string? Key { get; set; }
    public string? Value { get; set; }
}