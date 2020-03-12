using System;
using System.IO;
using System.Net.Sockets;

namespace ObliClient
{
    class MyTcpClient
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 4646);
            Console.WriteLine("Server connected");

            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            sw.WriteLine("Wack");

            string message = sr.ReadLine();

            while (message != null)
            {
                Console.WriteLine("Client " + message);
                sw.WriteLine(Console.ReadLine());
            }
        }
    }
}
