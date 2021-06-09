using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject graphicsTab;

    private List<Toggle> toggleList = new List<Toggle>();

    private string resolution;
    private int antiAliasing;
    private int isAnisotropicFilteringOn;
    private int isVSyncOn;
    private int targetFrameLimit;

    private void Awake()
    {
        toggleList = GetComponentsInChildren<Toggle>(true).ToList();

        resolution = PlayerPrefs.GetString("Resolution", "1920x1080");
        antiAliasing = PlayerPrefs.GetInt("AntiAliasing", 0);
        isAnisotropicFilteringOn = PlayerPrefs.GetInt("AnisotropicFiltering", 0);
        isVSyncOn = PlayerPrefs.GetInt("VSync", 0);
        targetFrameLimit = PlayerPrefs.GetInt("TargetFrameLimit", -1);

    }

    private void OnEnable()
    {
        // Toggle on the selected one
        switch (resolution)
        {
            case "3840x2160": toggleList.FirstOrDefault(toggle => toggle.name == "3840x2160Toggle").isOn = true; break;
            case "1920x1080": toggleList.FirstOrDefault(toggle => toggle.name == "1920x1080Toggle").isOn = true; break;
            case "1280x720": toggleList.FirstOrDefault(toggle => toggle.name == "1280x720Toggle").isOn = true; break;
            case "1024x768": toggleList.FirstOrDefault(toggle => toggle.name == "1024x768Toggle").isOn = true; break;
        }

        switch (antiAliasing)
        {
            case 0: toggleList.FirstOrDefault(toggle => toggle.name == "AntiAliasingOffToggle").isOn = true; break;
            case 2: toggleList.FirstOrDefault(toggle => toggle.name == "AntiAliasing2xToggle").isOn = true; break;
            case 4: toggleList.FirstOrDefault(toggle => toggle.name == "AntiAliasing4xToggle").isOn = true; break;
            case 8: toggleList.FirstOrDefault(toggle => toggle.name == "AntiAliasing8xToggle").isOn = true; break;
            case 16: toggleList.FirstOrDefault(toggle => toggle.name == "AntiAliasing16xToggle").isOn = true; break;
        }

        switch (isAnisotropicFilteringOn)
        {
            case 0: toggleList.FirstOrDefault(toggle => toggle.name == "AnisotropicDisableToggle").isOn = true; break;
            case 1: toggleList.FirstOrDefault(toggle => toggle.name == "AnisotropicEnableToggle").isOn = true; break;
        }

        switch (isVSyncOn)
        {
            case 0: toggleList.FirstOrDefault(toggle => toggle.name == "VSyncDisableToggle").isOn = true; break;
            case 1: toggleList.FirstOrDefault(toggle => toggle.name == "VSyncEnableToggle").isOn = true; break;
        }

        switch (targetFrameLimit)
        {
            case -1: toggleList.FirstOrDefault(toggle => toggle.name == "FrameRateLimitOffToggle").isOn = true; break;
            case 30: toggleList.FirstOrDefault(toggle => toggle.name == "FrameRateLimit30Toggle").isOn = true; break;
            case 60: toggleList.FirstOrDefault(toggle => toggle.name == "FrameRateLimit60Toggle").isOn = true; break;
            case 90: toggleList.FirstOrDefault(toggle => toggle.name == "FrameRateLimit90Toggle").isOn = true; break;
            case 120: toggleList.FirstOrDefault(toggle => toggle.name == "FrameRateLimit120Toggle").isOn = true; break;
        }
    }

    public void ApplyGraphics()
    {
        // UPDATE RESOLUTION
        int separator = resolution.IndexOf("x");
        string horizontalRes = resolution.Substring(0, separator);
        string verticalRes = resolution.Substring(separator + 1);

        Screen.SetResolution(int.Parse(horizontalRes), int.Parse(verticalRes), true);

        // UPDATE ANTIALIASING
        QualitySettings.antiAliasing = antiAliasing;

        // UPDATE ANISOTROPIC FILTERING
        QualitySettings.anisotropicFiltering = isAnisotropicFilteringOn == 0 ? AnisotropicFiltering.Disable : AnisotropicFiltering.ForceEnable;

        // UPDATE VSYNC
        QualitySettings.vSyncCount = isVSyncOn == 0 ? 0 : 1;

        // UPDATE TARGET FRAMERATE
        Application.targetFrameRate = targetFrameLimit;
    }


    #region Game Settings

    #endregion

    #region Graphics Settings

    #region ResolutionToggles
    public void SetResolution3840x2160(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetString("resolution", "3840x2160");
            resolution = "3840x2160";
        }
    }

    public void SetResolution1920x1080(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetString("resolution", "1920x1080");
            resolution = "1920x1080";
        }
    }

    public void SetResolution1280x720(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetString("resolution", "1280x720");
            resolution = "1280x720";
        }
    }

    public void SetResolution1024x768(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetString("resolution", "1024x768");
            resolution = "1024x768";
        }
    }
    #endregion

    #region AntiAliasing

    public void SetAntiAliasingOff(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AntiAliasing", 0);
            antiAliasing = 0;
        }
    }

    public void SetAntiAliasing2x(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AntiAliasing", 2);
            antiAliasing = 2;
        }
    }

    public void SetAntiAliasing4x(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AntiAliasing", 4);
            antiAliasing = 4;
        }
    }

    public void SetAntiAliasing8x(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AntiAliasing", 8);
            antiAliasing = 8;
        }
    }

    public void SetAntiAliasing16x(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AntiAliasing", 16);
            antiAliasing = 16;
        }
    }

    #endregion

    #region AnisotropicFiltering

    public void SetAnisotropicFilteringOn(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AnisotropicFiltering", 1);
            isAnisotropicFilteringOn = 1;
        }
    }

    public void SetAnisotropicFilteringOff(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("AnisotropicFiltering", 0);
            isAnisotropicFilteringOn = 0;
        }
    }

    #endregion

    #region VSyncToggles

    public void SetVSyncOn(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("VSync", 1);
            isVSyncOn = 1;
        }
    }

    public void SetVSyncOff(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("VSync", 0);
            isVSyncOn = 0;
        }
    }

    #endregion

    #region Target FrameRate

    public void SetTargetFrameRateOff(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("TargetFrameLimit", -1);
            targetFrameLimit = -1;
        }
    }

    public void SetTargetFrameRate30(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("TargetFrameLimit", 30);
            targetFrameLimit = 30;
        }
    }

    public void SetTargetFrameRate60(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("TargetFrameLimit", 60);
            targetFrameLimit = 60;
        }
    }

    public void SetTargetFrameRate90(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("TargetFrameLimit", 90);
            targetFrameLimit = 90;
        }
    }

    public void SetTargetFrameRate120(bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt("TargetFrameLimit", 120);
            targetFrameLimit = 120;
        }
    }


    #endregion

    #endregion
}
