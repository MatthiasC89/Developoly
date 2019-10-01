using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Developoly.Server.Entities;
using Developoly.Server.Services;

namespace Developoly.Server.Core
{
    public class Server
    {
        TcpListener _server = null;

        private bool _isServerFull = false;

        private const int port = 1234;

        private int _byteSize = 1024 * 1024;

        private Service service;
        public Service Service { get => service; set => service = value; }

        private Dictionary<int, TcpClient> clients = new Dictionary<int, TcpClient>();
        public Dictionary<int, TcpClient> Clients { get => clients; set => clients = value; }

        public JsonSerializerSettings jsonSetting = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore

        };

        public Server()
        {
            Service = new Service(Clients);
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            StartListener();
        }

        public void StartListener()
        {
            try
            {
                while (true && !_isServerFull)
                {
                    Console.WriteLine("Waiting for a connection...");
                    TcpClient client = _server.AcceptTcpClient();
                    Console.WriteLine("Connected client !");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDevice));
                    t.Start(client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Server is closed");
                _server.Stop();
            }
        }

        public void HandleDevice(object obj)
        {
            TcpClient client = (TcpClient)obj;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            clients.Add(threadId, client);
            NetworkStream stream = client.GetStream();
            
            try
            {
                while (true)
                {
                    byte[] bytes = new byte[_byteSize];
                    stream.Read(bytes, 0, bytes.Length);
                    Communication info = JsonConvert.DeserializeObject<Communication>(Encoding.Unicode.GetString(bytes), jsonSetting);

                    Console.WriteLine("Client n°{1}: Received: {0}", info.Data, threadId);

                    List<Communication> result = service.ReceiveInfo(info, threadId);

                    service.SendToClient(stream, Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(result[0], jsonSetting)));
                  
                    Console.WriteLine("Client n°{1}: Sent: {0}", result[0].Data, Thread.CurrentThread.ManagedThreadId);

                    service.SendToOther(threadId, result[1]);

                }
            }
            catch
            {
                Console.WriteLine("Client n° {0} disconnected", Thread.CurrentThread.ManagedThreadId);
                Clients.Remove(threadId);
                service.SendToOther(new Communication("RemovePlayerSuccess", Clients.Count.ToString()));
                client.Close();
            }
        }

        


    }
}