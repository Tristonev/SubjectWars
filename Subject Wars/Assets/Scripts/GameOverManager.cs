using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFader;

    public void PlayAgain()
    {
        screenFader.FadeToColor("BaseLevel");
    }

    public void QuitGame()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
