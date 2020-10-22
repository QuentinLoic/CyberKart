using System.Collections.Generic;

using UnityEngine;

    public class LoginClient : BaseClient
    {
        public static LoginClient instance;

        public LoginClientSend sender;

        public LoginClient(string _ip, int _port)
        {
            if (instance == null)
            {
                instance = this;
            }
            ip = _ip;
            port = _port;
            tcp = new TCP(this);
            sender = new LoginClientSend(this);
        }

        override protected void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)LoginServerPacketsType.welcome, LoginClientHandler.Welcome},
        };
            Debug.Log("Initialized packets");
        }
    }