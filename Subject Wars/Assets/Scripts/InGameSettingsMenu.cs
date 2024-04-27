using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class InGameSettingsMenu : MonoBehaviour
{
    [Header("Audio")]
    /* Reference to the audio mixer of the current scene */
    [SerializeField] AudioMixer audioMixer;
    /* Reference to the Slider within the settings menu */
    [SerializeField] Slider masterVolumeSlider;
    /* Reference to the settings canvas */
    [SerializeField] Canvas canvas;

    [Header("Resolution")]
    /* Reference to the dropdown within the settings menu */
    [SerializeField] TMP_Dropdown resDropdown;
    /* Reference to the fullscreen toggle within the settings menu */
    [SerializeField] Toggle fullscreenToggle;
    /* Reference to the array that holds all of the resolution options */
    Resolution[] resolutions;
    /* fullscreen status that is updated according to the player prefs */
    int fullscreenStatus;

    /* On start, this script will grab previously set values from a different instance of the game. These values include the master volume,
    * Resolution, and whether the game was in fullscreen or not. We then update these values to the current game state 
    */
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("InGameMasterVolume");
        InGameGetResolutionOptions();
        fullscreenStatus = PlayerPrefs.GetInt("fullscreen");
        InGameCheckFullscreen(fullscreenStatus);
        resDropdown.value = PlayerPrefs.GetInt("resolution");
        InGameSetResolution();
    }

    /* The settings canvas is on default invisible/disabled. This function will allow the settings canvas to open, or become visible to the user
    */
    public void InGameOpenSettings()
    {
        canvas.enabled = true;
    }

    /* This function will close the settings menu 
    */
    public void InGameCloseSettings()
    {
        canvas.enabled = false;
    }

    /* This function will take a slider value, and set it to a player preference, which will save the value permanently
    */
    public void InGameSetMasterVolume()
    {
        audioMixer.SetFloat("InGameMasterVolume", InGameConvertToDec(masterVolumeSlider.value));
        PlayerPrefs.SetFloat("InGameMasterVolume", masterVolumeSlider.value);
    }

    /* Conversion method to convert a slider value to a decimal
    */
    float InGameConvertToDec(float sliderValue)
    {
        return Mathf.Log10(Mathf.Max(sliderValue, 0.0001f)) * 20;
    }

    /* This method is called initially, and will grab all of the resolution options on the users machine
    */
    void InGameGetResolutionOptions()
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

    /* This method will set the resolution and fullscreen status of the users screen, depending on when they change the values
    */
    public void InGameSetResolution()
    {
        Screen.SetResolution(resolutions[resDropdown.value].width, resolutions[resDropdown.value].height, fullscreenToggle.isOn);
        PlayerPrefs.SetInt("fullscreen", InGameConvertToInt(fullscreenToggle.isOn));
        PlayerPrefs.SetInt("resolution", resDropdown.value);
    }

    /* This method will check whether the status of the screen is fullscreen or not
    */
    public void InGameCheckFullscreen(int fullscreenStatus)
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

    /* This method will convert a boolean to an integer 
    */
    int InGameConvertToInt(bool toggle)
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
