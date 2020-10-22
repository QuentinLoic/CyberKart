using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartController : MonoBehaviour
{
    [SerializeField] private Vector2 _position = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _position = new Vector2(Input.GetAxis("Vertical"),Input.GetAxis("Horizontal"));
    }

    public Vector2 GetPosition()
    {
        return _position;
    }
}
