using StackExchange.NetGain;
using StackExchange.NetGain.WebSockets;
using System;
using System.Net;

namespace ScoketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Loopback, 6002);
            using (var server = new TcpServer())
            {
                server.ProtocolFactory = WebSocketsSelectorProcessor.Default;
                server.ConnectionTimeoutSeconds = 60;
                server.Received += msg =>
                {
                    var conn = (WebSocketConnection)msg.Connection;
                    string reply = (string)msg.Value + " / " + conn.Host;
                    Console.WriteLine("[server] {0}", msg.Value);
                    msg.Connection.Send(msg.Context, reply);
                };
                server.Start("abc", endpoint);
                Console.WriteLine("Server running");

                Console.ReadKey();
            }
            Console.WriteLine("Server dead; press any key");
            Console.ReadKey();
        }
    }
}
