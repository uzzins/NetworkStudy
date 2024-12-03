using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace StremRead_20241203
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] buffer = new char[100];
            TcpClient tcpClient = new TcpClient("localhost", 3000);
            NetworkStream ns = tcpClient.GetStream();

            using (StreamReader sr = new StreamReader(ns)) {
                string str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
                str = sr.ReadLine();
                Console.WriteLine(str);
            }
            ns.Close();
            tcpClient.Close();
        }
    }
}
