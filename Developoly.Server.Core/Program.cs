using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Developoly.Server.Core
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("==================");
            Console.WriteLine("Server Starting...");
            Console.WriteLine("==================");
            Thread threadServer = new Thread(delegate ()
            {
                Server myServer = new Server();
            });

            threadServer.Start();

            Console.WriteLine("Server Started : " + IPAddress.Any + ":" + "1234");
            Console.WriteLine("==================");
        }
    }
}
