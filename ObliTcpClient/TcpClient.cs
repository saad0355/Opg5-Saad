using System;
using System.IO;
using System.Net.Sockets;

namespace ObliTcpClient
{
    public class TcpClient
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("192.168.24.205", 6789);
            Console.WriteLine("Server connected");

            NetworkStream ns = client.();
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
