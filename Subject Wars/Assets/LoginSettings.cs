using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginSettings : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider masterVolumeSlider;
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
        masterVolumeSlider.value = PlayerPrefs.GetFloat("LoginMasterVolume");
        LoginGetResolutionOptions();
        fullscreenStatus = PlayerPrefs.GetInt("fullscreen");
        LoginCheckFullscreen(fullscreenStatus);
        resDropdown.value = PlayerPrefs.GetInt("resolution");
        LoginSetResolution();
    }


    public void LoginOpenSettings()
    {
        canvas.enabled = true;
    }

    public void LoginCloseSettings()
    {
        canvas.enabled = false;
    }

    public void LoginSetMasterVolume()
    {
        audioMixer.SetFloat("LoginMasterVolume", LoginConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("LoginMasterVolume", masterVolumeSlider.value);
    }
    float LoginConvertToDec(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    void LoginGetResolutionOptions()
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

    public void LoginSetResolution()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
        PlayerPrefs.SetInt("fullscreen", LoginConvertToInt(fullscreenToggle.isOn));
        PlayerPrefs.SetInt("resolution", resDropdown.value);
    }

    public void LoginCheckFullscreen(int fullscreenStatus)
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

    int LoginConvertToInt(bool toggle)
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
