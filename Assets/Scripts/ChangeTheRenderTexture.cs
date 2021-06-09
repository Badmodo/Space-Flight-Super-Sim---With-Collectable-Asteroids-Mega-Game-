using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTheRenderTexture : MonoBehaviour
{
    [SerializeField] RenderTexture texture;
    [SerializeField] RawImage raw;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }

        RenderTexture texture2 = new RenderTexture(texture);
        texture2.width = Screen.width;
        texture2.depth = Screen.height;
        texture.depth = 16;
        cam.targetTexture = texture2;
        raw.texture = texture2;
    }
}
