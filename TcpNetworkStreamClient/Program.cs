
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpNetworkStreamClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("localhost", 7);
            NetworkStream ns = tcpClient.GetStream();
            Console.WriteLine("클라이언트");
            byte[] buffer = new byte[1024];
            byte[] sendMessage = Encoding.ASCII.GetBytes("Hello World!");
            ns.Write(sendMessage,0,sendMessage.Length);
            int totalCnt = 0;
            int readCnt = 0;

            while (totalCnt<sendMessage.Length){
                readCnt = ns.Read(buffer, 0, buffer.Length);
                totalCnt += readCnt;
                string recieveMssage = Encoding.ASCII.GetString(buffer);
                Console.WriteLine(recieveMssage);
            }
            Console.WriteLine("받은 문자열 바이트 수: {0}",totalCnt);
            ns.Close();
            tcpClient.Close();
        }
    }
}
