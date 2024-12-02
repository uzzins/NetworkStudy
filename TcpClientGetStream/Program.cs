using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpClientGetStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1",13);
            if (tcpClient.Connected)
            {
                Console.WriteLine("서버 연결 성공");
                NetworkStream ns = tcpClient.GetStream();
                string Message = "Hello World!";
                byte[] sendByteMessage = Encoding.ASCII.GetBytes(Message);
                ns.Write(sendByteMessage,0, sendByteMessage.Length);

                byte[] receiveByteMessage = new byte[32];
                ns.Read(receiveByteMessage, 0, receiveByteMessage.Length);
                string receiveMessage = Encoding.ASCII.GetString(receiveByteMessage);
                Console.WriteLine(receiveMessage);
                ns.Close();

            }
            else
            {
                Console.WriteLine("서버 연결 실패");
            }
            tcpClient.Close();
        }
    }
}
