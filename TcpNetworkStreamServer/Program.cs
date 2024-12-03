using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpNetworkStreamServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, 7);
            tcpListener.Start();
            byte[] Buffer = new byte[1024];
            int TotalByteCount = 0;
            int ReadbyteCount = 0;

            Console.WriteLine("서버");

            TcpClient tcpClient = tcpListener.AcceptTcpClient(); // 대기상태
            NetworkStream ns = tcpClient.GetStream();//stream 반환

            while (true)
            {
                ReadbyteCount = ns.Read(Buffer,0, Buffer.Length);
                if(ReadbyteCount == 0) break;
                TotalByteCount += ReadbyteCount;
                ns.Write(Buffer, 0,ReadbyteCount);
                Console.WriteLine(Encoding.ASCII.GetString(Buffer));
            }
            ns.Close();
            tcpClient.Close();
            tcpListener.Stop();

        }
    }
}
