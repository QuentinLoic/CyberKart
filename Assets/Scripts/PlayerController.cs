using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2 _position = new Vector2();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        SendInputToServer();
    }

    /// <summary>Sends player input to the server.</summary>
    private void SendInputToServer()
    {
        _position = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        ClientSend.PlayerMovement(_position);
    }

    public Vector2 GetPosition()
    {
        return _position;
    }
}
