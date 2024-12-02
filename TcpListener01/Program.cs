﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpListener01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(ip, 13); //지정된 ip와 port 번호에서 연결을 수신 대기하겠다는 의미.
            Console.WriteLine("{0}", tcpListener.LocalEndpoint.ToString());
            Console.ReadKey();
        }
    }
}
