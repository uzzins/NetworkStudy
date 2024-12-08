using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWriter01_20241209
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();

            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();

            using(BinaryWriter bw = new BinaryWriter(ns))
            {
                bool YesNo = true;
                int Number = 12;
                float Pi = 3.14f;
                string message = "Hello World!";

                bw.Write(YesNo);
                bw.Write(Number);
                bw.Write(Pi);
                bw.Write(message);
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();

        }
    }
}
