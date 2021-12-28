using System;
using System.Text;
using Chat.Network;
using Chat.Security;
using System.Threading;
using Chat.Network.Packets;
using System.Collections.Specialized;
using Chat.Cli.Rooms;
using Console = Colorful.Console;
using System.Drawing;

namespace Chat
{
    class Program
    {
        public static Client client;
        private static readonly string SERVER_ADRESS = "127.0.0.1";
        private static readonly int SERVER_PORT = 8001;
        private static readonly string SERVER_PASSWORD = "1234";

        static void Main(string[] args)
        {
            Console.WriteLine("Chat",Color.Tomato);
            Console.WriteLine("Press any key to continue...");
            Console.Read();
            Console.Clear();
            Console.WriteLine("Connecting..");
            client = new Client("127.0.0.1", 8001,"1234");
            client.Connect();
            client.NewPacket += Client_NewPacket;
            Console.Write(" Sucess!");
            Console.Clear();

            while(true)
            {
                new MainMenu_Room(client).Show();
            }

        }

        private static void Client_NewPacket(Packet packet)
        {
            if(packet != Packet.Empty)
            {
               
                Console.WriteLine();
                Console.WriteLine(packet.ToString());
            }
        }
    }
}
