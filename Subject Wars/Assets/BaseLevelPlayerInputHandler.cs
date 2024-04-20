using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseLevelPlayerInputHandler : MonoBehaviour
{
    [SerializeField] Canvas baseLevelPause;
    [SerializeField] Canvas baseLevelSettings;
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

    public void Resume()
    {
        baseLevelPause.enabled = false;
        Time.timeScale = 1;
    }

    public void BaseOpenSettings()
    {
        baseLevelSettings.enabled = true;
    }

    public void BaseQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
