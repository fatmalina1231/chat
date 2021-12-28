using System;
using System.Collections.Generic;
using System.Text;
using Chat.Network.Packets;
using Chat_Server.Network;
using Chat_Server.DB;

namespace Chat_Server.Core
{
    class Register
    {
        public Register(Packet packet,Client client)
        {
            string nick = packet.GetArgument("nick").value;
            string password = packet.GetArgument("password").value;
            string error = string.Empty;

            if(DataBase.Users.UserExits(nick)) { error = "This nickname is alredy taken"; }
            if(DataBase.Users.IsBanned(nick)) { error = "Your account is banned :P"; }

            if(error == string.Empty)
            {
                DataBase.Users.CreateNew(nick, password);
                Console.WriteLine("Creatgin New user [{0}]", nick);
            }

            Packet res_packet = new Packet() { name = "register", args = new Argument[] {
                new Argument("type","response"),
                new Argument("error",error)
            }};

            Program.server.Send(res_packet, client);
        }
    }
}
