using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AcceptTcpClient01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 13);
            tcpListener.Start();
            Console.WriteLine("대기 상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient(); //대기상태
            Console.WriteLine("대기 상태 종료");
            tcpListener.Stop();

        }
    }
}
