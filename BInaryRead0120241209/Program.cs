using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BInaryRead01_20241209
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool YesNo;
            int Number;
            float Pi;
            string message;
            TcpClient tcpClient = new TcpClient("127.0.0.1", 3000);
            NetworkStream ns = tcpClient.GetStream();

            using (BinaryReader reader = new BinaryReader(ns)) { 
               YesNo = reader.ReadBoolean();
                Number = reader.ReadInt32();
                Pi = reader.ReadSingle();
                message = reader.ReadString();
            }
            ns.Close();
            tcpClient.Close();

            Console.WriteLine(YesNo);
            Console.WriteLine(Number);
            Console.WriteLine(Pi);
            Console.WriteLine(message);

        }
    }
}
