using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFTest.Handler
{
    public class SocketHandler
    {
        public const int BufferSize = 4096;
        public string basestringjson = string.Empty;

        WebSocket _socket;

        SocketHandler(WebSocket socket)
        {
            _socket = socket;
        }

        async Task EchoLoop()
        {
            var buffer = new byte[BufferSize];
            var seg = new ArraySegment<byte>(buffer);


            while (_socket.State == WebSocketState.Open)
            {
                var incoming = await _socket.ReceiveAsync(seg, CancellationToken.None);
                string receivemsg = Encoding.UTF8.GetString(buffer, 0, incoming.Count);
                if (receivemsg == "get")
                {
                    string stringJson = "";

                    List<AddressMatchProgressModel> infolist = new List<AddressMatchProgressModel>();
                    Hashtable newtable = CommonInfo.ProgressInfo;
                    if (newtable != null)
                    {
                        try
                        {
                            foreach (DictionaryEntry i in newtable)
                            {
                                AddressMatchProgressModel pgmodel = new AddressMatchProgressModel();
                                pgmodel = (AddressMatchProgressModel)i.Value;
                                infolist.Add(pgmodel);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    stringJson = JsonConvert.SerializeObject(infolist);


                    string userMsg = stringJson;
                    byte[] x = Encoding.UTF8.GetBytes(userMsg);
                    var outgoing = new ArraySegment<byte>(x);
                    await _socket.SendAsync(outgoing, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                //var incoming = await _socket.ReceiveAsync(seg, CancellationToken.None);
                //var outgoing = new ArraySegment<byte>(buffer, 0, incoming.Count);
                //await _socket.SendAsync(outgoing, WebSocketMessageType.Text, true, CancellationToken.None);

            }
        }

        static async Task Acceptor(HttpContext hc, Func<Task> n)
        {
            if (!hc.WebSockets.IsWebSocketRequest)
                return;

            var socket = await hc.WebSockets.AcceptWebSocketAsync();
            var h = new SocketHandler(socket);
            await h.EchoLoop();
        }

        /// <summary>
        /// branches the request pipeline for this SocketHandler usage
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app)
        {
            app.UseWebSockets();
            app.Use(SocketHandler.Acceptor);
        }
    }

    internal class AddressMatchProgressModel
    {
    }
}
