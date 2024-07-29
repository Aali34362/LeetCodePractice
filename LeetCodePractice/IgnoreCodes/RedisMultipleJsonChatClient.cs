using System.Net.Sockets;
using System.Text.Json;
using System.Text;

namespace LeetCodePractice.IgnoreCodes;

public class RedisMultipleJsonChatClient
{
    public static void RedisMultipleJsonChatClientMain()
    {
        string serverIp = "127.0.0.1";
        Console.WriteLine("Connected to chat server.");

        using TcpClient client = new TcpClient(serverIp, 5000);
        using NetworkStream stream = client.GetStream();

        while (true)
        {
            try
            {
                Console.WriteLine("Enter command (GET, POST, UPDATE, DELETE, DELETEALL, GETALL) or 'exit' to quit:");
                string action = Console.ReadLine()!;
                if (action.ToLower() == "exit")
                {
                    break;
                }

                var command = new DictionaryCommand
                {
                    Action = action.ToUpper(),
                    KeyValuePairs = new Dictionary<string, string>()
                };

                switch (action.ToUpper())
                {
                    case "GET":
                    case "DELETE":
                        Console.WriteLine("Enter key:");
                        string key = Console.ReadLine()!;
                        command.KeyValuePairs[key] = string.Empty;
                        break;

                    case "POST":
                    case "UPDATE":
                        Console.WriteLine("Enter key-value pairs in JSON format (e.g., {\"User1\": {\"Name\": \"John\", \"Age\": 30}, \"User2\": {\"Name\": \"Doe\", \"Age\": 25}}):");
                        string jsonInput = Console.ReadLine()!;
                        try
                        {
                            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonInput);
                            if (keyValuePairs != null)
                            {
                                foreach (var kvp in keyValuePairs)
                                {
                                    command.KeyValuePairs[kvp.Key] = kvp.Value.ToString();
                                }
                            }
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine("Invalid JSON format. Please try again.");
                            continue;
                        }
                        break;

                    case "DELETEALL":
                    case "GETALL":
                        // No additional input needed
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        continue;
                }

                string message = JsonSerializer.Serialize(command);
                byte[] data = Encoding.ASCII.GetBytes(message);
                 stream.Write(data, 0, data.Length);

                byte[] responseBuffer = new byte[1024];
                int byteCount = stream.Read(responseBuffer, 0, responseBuffer.Length);
                string response = Encoding.ASCII.GetString(responseBuffer, 0, byteCount);
                Console.WriteLine("Response: " + response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
public class DictionaryCommand
{
    public string? Action { get; set; }
    public Dictionary<string, string>? KeyValuePairs { get; set; }
}