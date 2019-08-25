using System;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using Demo;
namespace p2
{
    internal class Program
    {
        private static byte[] result = new byte[1024];
        public static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            client.Connect(new IPEndPoint(ip, 6999));

            var demoRequest = new DemoRequest();
            demoRequest.Uid = 1;
            demoRequest.Account = "123";
            demoRequest.Password = "123";

            client.Send(demoRequest.ToByteArray());
            var recvLen = client.Receive(result);
            var proto = new byte[recvLen];
            Buffer.BlockCopy(result, 0, proto, 0, recvLen);
            var response = DemoResponse.Parser.ParseFrom(proto);
            Console.WriteLine(response.Uid);
            Console.WriteLine(response.IsOk);
        }
    }
}