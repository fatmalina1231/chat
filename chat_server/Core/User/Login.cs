using System;
using System.Collections.Generic;
using System.Text;
using Chat.Network.Packets;
using Chat_Server.Network;
using Chat_Server.DB;

namespace Chat_Server.Core
{
    class Login
    {
        public Login(Packet packet,Client client)
        {
            string nick = packet.GetArgument("nick").value;
            string password = packet.GetArgument("password").value;
            string error = string.Empty;

            if(!DataBase.Users.GetAuth(nick,password)) { error = "Wrong password or nickname"; }
            if (DataBase.Users.IsBanned(nick)) { error = "Your account is banned :P"; }
            
            Packet login_response = new Packet() { name = "login", args = new Argument[] {
                new Argument("type","response"),
                new Argument("error",error)
            } };

            Program.server.Send(login_response,client);
        }
    }
}
