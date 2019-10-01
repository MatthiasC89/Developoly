
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using Developoly.Server.Services.Entities;
using Developoly.Server.Entities;
using System.Net.Sockets;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Developoly.Server.Services
{
    public partial class Service
    {

        public void SendToClient(NetworkStream streamClient, byte[] bufferRequest)
        {
            streamClient.Write(bufferRequest, 0, bufferRequest.Length);
            streamClient.Flush();
        }

        public void SendToOther(Communication result)
        {
            if (Clients.Count > 0)
            {
                byte[] outHisStream = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(result, jsonSetting));
                foreach (KeyValuePair<int, TcpClient> c in Clients)
                {
                    c.Value.GetStream().Write(outHisStream, 0, outHisStream.Length);
                }
                Console.WriteLine("Other clients: Sent: {0}", result.Data);
            }
        }

        public void SendToOther(int idClient, Communication result)
        {
            if (result != null && Clients.Count > 1)
            {
                byte[] outHisStream = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(result, jsonSetting));
                foreach (KeyValuePair<int, TcpClient> c in Clients)
                {
                    if (c.Key != idClient)
                    {
                        c.Value.GetStream().Write(outHisStream, 0, outHisStream.Length);
                    }
                }
                Console.WriteLine("Other clients: Sent: {0}", result.Data);
            }
        }

    }
}
