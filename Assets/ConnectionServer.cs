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
    private TcpClient tcpClient;
    private KartController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<KartController>();
        tcpClient = new TcpClient(ip, port);
        if (tcpClient.Connected)
        {
            Debug.Log($"Connection to: ${ip} on port : ${port}");
        }

    }

    // Update is called once per frame
    void Update()
    {
        var buffer = new MemoryStream();
        buffer.SetLength(1024);

        var position = controller.GetPosition();
        var bytesX = BitConverter.GetBytes(position.x);
        buffer.Write(bytesX, 0, bytesX.Length);

        var stream = tcpClient.GetStream();
        stream.BeginWrite(buffer.ToArray(), 0, buffer.ToArray().Length,EndSend,buffer);
    }

    void EndSend(IAsyncResult result)
    {
        Debug.Log("data send");
    }
}
