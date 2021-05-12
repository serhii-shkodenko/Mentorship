using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Lecture7
{
    public class WorkingWithNetworkStream
    {
        private const string HostAddress = "www.google.com";
        private const string HostPageToNavigate = "/search?q=dotnet";

        public class Client
        {
            // Get raw http response.
            public string GetRawResponseFromServer()
            {
                // Builder to store the response representation chunks.
                var builder = new StringBuilder();

                try
                {
                    using var client = new TcpClient(HostAddress, 80)
                    {
                        SendTimeout = 500,
                        ReceiveTimeout = 1000
                    };

                    // Request part.
                    var request = $"GET {HostPageToNavigate} HTTP/1.1" + Environment.NewLine +
                        $"Host: {HostAddress}" + Environment.NewLine +
                        "Connection: close" + Environment.NewLine + Environment.NewLine;

                    var bytesToSend = Encoding.UTF8.GetBytes(request);

                    using var stream = client.GetStream(); // NetworkStream here is.

                    // Send the message to the server.
                    stream.Write(bytesToSend, 0, bytesToSend.Length);

                    Console.WriteLine("Sent: {0}", request);

                    // Response part.
                    // Create buffer to store the response bytes.
                    var buffer = new byte[16384];

                    // Read the server response into a memory.
                    using var memoryStream = new MemoryStream();

                    int numBytesRead;
                    while ((numBytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        memoryStream.Write(buffer, 0, numBytesRead);
                    }

                    builder.Append(Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length));
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }

                var rawResponse = builder.ToString();

                Console.WriteLine("Received: {0}", rawResponse);

                return rawResponse;
            }
        }
    }
}