using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ObliTCPServer
{
    class MyTcpListener
    {
        private static List<Book> books = new List<Book>()
        {
            new Book("Dø", "Carl", 256, "1234567891011"),
            new Book("Wack", "Jonas", 500, "1234567891012")
        };

        public void Start()
        {

            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");


            TcpListener serverSocket = new TcpListener(ipAddress, 4646);

            serverSocket.Start();
            Console.WriteLine("Server started");


            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = connectionSocket;
                    Console.WriteLine("Server activated");
                    DoClient(tempSocket);
                });

            }
            //connectionSocket.Close();
        }

        public static void DoClient(TcpClient socket)
        {
            Stream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;

            string message = sr.ReadLine();
            string answer = "";
            while (message != null && message != "")
            {
                string[] messagArray = message.Split("");
                string param = message.Substring(message.IndexOf("") + 1);
                string command = messagArray[0];

                switch (command)
                {
                    case "GetAll":
                        sw.WriteLine("Get all received");
                        sw.WriteLine(JsonConvert.SerializeObject(books));
                        break;
                    case "Get":
                        sw.WriteLine("Get reveived");
                        sw.WriteLine(books.Find(i => i.Isbn13 == param));
                        break;
                    case "Save":
                        sw.WriteLine("Saved");
                        Book saveBook = JsonConvert.DeserializeObject<Book>(param);
                        books.Add(saveBook);
                        break;;
                }
                Console.WriteLine("Client: " + message);
                answer = message.ToUpper();
                sw.WriteLine(answer);
                message = sr.ReadLine();
            }

            ns.Close();
        }
    }
}
