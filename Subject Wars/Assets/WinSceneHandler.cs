using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneHandler : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFader;
    public void WinPlayAgain()
    {
        screenFader.FadeToColor("BaseLevel");
    }

    public void WinQuit()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
