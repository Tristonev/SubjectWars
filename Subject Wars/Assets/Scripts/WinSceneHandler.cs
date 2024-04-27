using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneHandler : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFader;

    /* screenfader will fade to black and load the base level scene */
    public void WinPlayAgain()
    {
        screenFader.FadeToColor("BaseLevel");
    }

    /* screenfader will fade to black and load the main menu scene */
    public void WinQuit()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
