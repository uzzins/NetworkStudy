using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStreamServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"),13);
            tcpListener.Start();
            Console.WriteLine("대기상태");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream ns = tcpClient.GetStream();
            byte[] receiveMessage = new byte[100];
            ns.Read(receiveMessage, 0, 100);
            string strMessage = Encoding.ASCII.GetString(receiveMessage);
            Console.WriteLine(strMessage);

            string echoMessage = "Hi~~~";
            byte[] sendMessage = Encoding.ASCII.GetBytes(echoMessage);
            ns.Write(sendMessage, 0, sendMessage.Length);
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();

        }
    }
}
