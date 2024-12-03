using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriter01_20241203
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(3000);
            tcpListener.Start();
            TcpClient tcpClient = tcpListener.AcceptTcpClient();

            bool YesNo = false;
            int Val1 = 12;
            float Pi = 3.14f;
            string Message = "HelloWorld!";

            NetworkStream ns = tcpClient.GetStream();
            using (StreamWriter sw = new StreamWriter(ns))
            {
                sw.AutoFlush = true;
                sw.WriteLine(Val1);
                sw.WriteLine(YesNo);
                sw.WriteLine(Pi);
                sw.WriteLine(Message);

            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}
