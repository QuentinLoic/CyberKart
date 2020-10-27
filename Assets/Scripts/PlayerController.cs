using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 position = new Vector2();

    private void FixedUpdate()
    {
        SendInputToServer();
        SendLightControlToServer();
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        position = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        ClientSend.PlayerMovement(position);
    }
    
    private void SendLightControlToServer()
    {
        if (!Input.GetButtonDown("Light")) return;
        ClientSend.LightControl();
    }

    public Vector2 GetPosition()
    {
        return position;
    }
}
