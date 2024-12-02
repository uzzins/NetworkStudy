using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClient01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1",13);
            if (tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
            }
            else
            {
                Console.WriteLine("서버 연결 실패");
            }
            tcpClient.Close();
            Console.ReadKey();
        }
    }
}
