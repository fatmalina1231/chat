﻿using System;
using System.Collections.Generic;
using System.Text;
using Chat.Network;

namespace Chat.Cli.Rooms
{
    class MainMenu_Room : Room
    {
        private Client client;
        public MainMenu_Room(Client client)
        {
            Console.Clear();
            this.client = client;
            title = "MainMenu";
        }

        public override void Show()
        {
            if(client.logged)
            {
                switch (Input("$>", new string[] { "/friends", "/setting", "/test", "/exit" }))
                {
                    case "/friends":
                        new Friends_Room(client).Show();
                        break;
                    case "/settings":
                        Console.WriteLine("settings");
                        break;
                    case "/test":
                        Console.WriteLine("test");
                        break;
                    case "/exit":
                        return;
                    default:
                        Console.WriteLine("Unknown Command");
                        Show();
                        break;
                }
            }
            else
            {
                switch (Input("$>", new string[] { "/register", "/login", "/info", "/exit" }))
                {
                    case "/register":
                        new Register_Room(client).Show();
                        break;
                    case "/login":
                        new Login_Room(client).Show();
                        break;
                    case "/info":
                        break;
                    case "/exit":
                        return;
                    default:
                        Console.WriteLine("Unknown Command");
                        Show();
                        break;
                }
            }

                
            base.Show();
        }
    }
}
