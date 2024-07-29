using System.Net.Sockets;
using System.Text;

namespace LeetCodePractice.IgnoreCodes;

public static class ChatClient
{
    public static void ChatClientMain()
    {
        Console.Write("Enter server IP: ");
        string serverIp = "127.0.0.1";
        //string serverIp = Console.ReadLine()!;
        // 127.0.0.1:5000

        TcpClient client = new TcpClient(serverIp, 5000);
        NetworkStream stream = client.GetStream();

        Thread thread = new Thread(o => ReceiveData((TcpClient)o));
        thread.Start(client);

        Console.WriteLine("Connected to chat server.");
        string s;
        while (!string.IsNullOrEmpty(s = Console.ReadLine()))
        {
            byte[] buffer = Encoding.ASCII.GetBytes(s);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        client.Client.Shutdown(SocketShutdown.Send);
        thread.Join();
        stream.Close();
        client.Close();
    }

    private static void ReceiveData(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int byteCount;

        while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            Console.WriteLine("Server response: " + Encoding.ASCII.GetString(buffer, 0, byteCount));
        }
    }
}
