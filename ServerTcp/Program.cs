using System;
using ObliTCPServer;

namespace ServerTcp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyTcpListener server = new MyTcpListener();
            server.Start();
            Console.ReadLine();
        }
    }
}
