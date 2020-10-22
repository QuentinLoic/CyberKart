using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    public class LoginClientSend : BaseClientSend
    {

        #region Packets
        public LoginClientSend(IClient _client)
        {
            client = _client;
        }
        public void WelcomeReceived()
        {
            using (Packet _packet = new Packet((int)LoginClientPacketsType.welcomeReceived))
            {
                _packet.Write(LoginClient.instance.id);
                _packet.Write("Hello Server!");

                SendTCPData(_packet);
            }
        }

        #endregion
    }