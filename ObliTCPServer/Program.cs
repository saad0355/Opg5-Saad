using System;
using System.Collections.Generic;
using System;

namespace ObliTCPServer
{
    class Program
    {
        public void Main(string[] args)
        {
            MyTcpListener server = new MyTcpListener();
            server.Start();
            Console.ReadLine();
        }
    }
}
