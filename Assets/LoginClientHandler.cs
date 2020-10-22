using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class LoginClientHandler : MonoBehaviour
    {
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Debug.Log($"Message from server: {_msg}");
            LoginClient.instance.id = _myId;

            LoginClient.instance.sender.WelcomeReceived();
        }

    }
