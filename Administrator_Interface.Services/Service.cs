using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Administrator_Interface.Entities;

namespace Administrator_Interface.Services
{
    public class Service
    {
        private TcpClient _client;
        private NetworkStream _stream;

        private bool _isConnected;
        private int _byteSize = 1024 * 1024;

        public Service()
        {

        }


        public Service(string ip, int port)
        {
            _client = new TcpClient();
            try
            {
                _client.Connect(ip, port);
                _stream = _client.GetStream();
                _isConnected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        public Communication ReceiveData()
        {
            try
            {
                byte[] inStream = new byte[_byteSize];
                int sizeBuffer = _stream.Read(inStream, 0, (int)_client.ReceiveBufferSize);
                if (sizeBuffer > 0)
                {
                    return JsonConvert.DeserializeObject<Communication>(Encoding.Unicode.GetString(inStream));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The server is not started. Exception: " + e);
            }
            return null;
        }

        public void SendData(Communication info)
        {
            if (_isConnected)
            {
                byte[] outStream = Encoding.Unicode.GetBytes(JsonConvert.SerializeObject(info));
                _stream.Write(outStream, 0, outStream.Length);
                _stream.Flush();
            }
        }
        public void ReceiveInfo(Communication info)
        {
            switch (info.Action)
            {

                default:
                    break;
            }



        }

    }
}
