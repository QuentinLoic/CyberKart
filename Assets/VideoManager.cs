using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;
    public RawImage render;
    private Texture2D texture;

    private void Start()
    {
        instance = this;
        texture = new Texture2D(640,480);
    }

    public void ChangeImage(byte[] data)
    {

        texture.LoadImage(data);
        render.texture = texture;

    }
    
}
