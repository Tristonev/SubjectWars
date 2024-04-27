using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLevelPlayerInputHandler : MonoBehaviour
{

    /* Reference to the pause menu */
    [SerializeField] Canvas baseLevelPause;

    /* Reference to the settings menu within the pause menu */
    [SerializeField] Canvas baseLevelSettings;

    /* ScreenFader for the current scene */
    [SerializeField] ScreenFadeHandler screenFade;

    /* Checking every frame on whether or not the pause menu was pressed */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                baseLevelPause.enabled = true;
                Time.timeScale = 0;
            }
            else
            {
                baseLevelPause.enabled = false;
                Time.timeScale = 1;

            }
        }
    }

    /* Changes the flow of time to continue */
    public void Resume()
    {
        baseLevelPause.enabled = false;
        Time.timeScale = 1;
    }

    /* Opens the settings menu */
    public void BaseOpenSettings()
    {
        baseLevelSettings.enabled = true;
    }

    /* Exits the game to the main menu */
    public void BaseQuit()
    {
        Time.timeScale = 1;
        screenFade.FadeToColor("MainMenu");
    }

}
