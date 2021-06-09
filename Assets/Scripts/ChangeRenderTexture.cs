using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RenderRate {  r16 = 0, r32 = 1 };

public class ChangeRenderTexture : MonoBehaviour
{
    [SerializeField] RenderRate rate;
    [SerializeField] RawImage raw;
    [SerializeField] Camera cam;

    public RenderRate Rate
    {
        get => rate;
        set
        {
            Rate = value;
            ChangeBitRate(value);
        }
    }
    private void Start() => ChangeBitRate(rate);

    public void ChangeBitRate(RenderRate _rate)
    {
        if (cam.targetTexture != null) cam.targetTexture.Release();

        RenderTexture texture;

        switch (_rate)
        {
            case RenderRate.r16:
                texture = new RenderTexture(Screen.width, Screen.height, 16);
                break;
            
            case RenderRate.r32:
                texture = new RenderTexture(Screen.width, Screen.height, 32);
                break;

            default: return;
        }

        cam.targetTexture = texture;
        raw.texture = texture;
    }

    public void ChangeBitRate(int _rate)
    {
        ChangeBitRate((RenderRate)_rate);
    }
}
