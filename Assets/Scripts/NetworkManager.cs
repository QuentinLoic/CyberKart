using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    [SerializeField] private int targetFrameRate = 30;
    [SerializeField] private int refreshTime = 10;
    [SerializeField] private int connectionTimeOut = 2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Start()
    {
        
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        Debug.Log($"Set FrameRate to {targetFrameRate}");

        
        StartCoroutine(ConnnectClient());
    }

    private void OnApplicationQuit()
    {
        Client.instance.Disconnect();
    }

    private IEnumerator ConnnectClient()
    {
        while (!Client.instance.IsConnected)
        {
            Debug.Log($"Start connect to server");
            Client.instance.ConnectToServer();
            yield return new WaitForSeconds(connectionTimeOut);

            if (Client.instance.IsConnected)
            {
                Client.instance.tcp.onDisconnect.AddListener(OnTcpDisconnected);
                break;
            }

            Debug.Log($"Waiting {refreshTime}s before new connection");

            yield return new WaitForSeconds(refreshTime);
        }
        
    }

    private void OnTcpDisconnected()
    {
        StartCoroutine(ConnnectClient());
    }
}