using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ConnectionServer : MonoBehaviour
{
    [SerializeField] private int port = 8888;
    [SerializeField] private string ip = "localhost";
    private LoginClient client;
    private KartController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<KartController>();
        client = new LoginClient(ip, port);
        client.ConnectToServer();
       
    }

    // Update is called once per frame
    void Update()
    {
        var packet = new Packet();
        var pos = controller.GetPosition();
        packet.Write(pos.x);
        client.GetTCP().SendData(packet);
    }

    void EndSend(IAsyncResult result)
    {
        //Debug.Log("data send");
    }
}
