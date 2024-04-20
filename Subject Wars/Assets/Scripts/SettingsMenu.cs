using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using System.Linq;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] Slider inGameMasterVolumeSlider;
    [SerializeField] Canvas canvas;

    [Header("Resolution")]
    [SerializeField] TMP_Dropdown resDropdown;
    [SerializeField] Toggle fullscreenToggle;
    Resolution[] resolutions;

    int fullscreenStatus;
    int resolutionIndex;

    // Start is called before the first frame update
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        inGameMasterVolumeSlider.value = PlayerPrefs.GetFloat("InGameMasterVolume");
        GetResolutionOptions();
        fullscreenStatus = PlayerPrefs.GetInt("fullscreen");
        CheckFullscreen(fullscreenStatus);
        resDropdown.value = PlayerPrefs.GetInt("resolution");
        SetResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenSettings()
    {
        canvas.enabled = true;
    }

    public void CloseSettings()
    {
        canvas.enabled = false;
    }

    public void SetMasterVolume()
    {
        audioMixer.SetFloat("MasterVolume", ConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void SetInGameMasterVolume()
    {
        audioMixer.SetFloat("InGameMasterVolume", ConvertToDec(inGameMasterVolumeSlider.value));
        PlayerPrefs.SetFloat("InGameMasterVolume", inGameMasterVolumeSlider.value);
    }

    float ConvertToDec(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    void GetResolutionOptions()
    {
        resDropdown.ClearOptions();
        resolutions = Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct().ToArray();
        for(int i = 0; i < resolutions.Length; i++)
        {
            TMP_Dropdown.OptionData newOption;
            newOption = new TMP_Dropdown.OptionData(resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString());
            resDropdown.options.Add(newOption);
        }
    }

    public void SetResolution()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
        PlayerPrefs.SetInt("fullscreen", ConvertToInt(fullscreenToggle.isOn));
        PlayerPrefs.SetInt("resolution", resDropdown.value);
    }

    public void CheckFullscreen(int fullscreenStatus)
    {
        if(fullscreenStatus == 0)
        {
            fullscreenToggle.isOn = false;
        }
        else
        {
            fullscreenToggle.isOn = true;
        }
    }

    int ConvertToInt(bool toggle)
    {
        if(toggle == false)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
