using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    [SerializeField] ScreenFadeHandler screenFader;

    //Fade to black, and load up base level scene
    public void PlayAgain()
    {
        screenFader.FadeToColor("BaseLevel");
    }

    //Fade to black, and load up main manu scene
    public void QuitGame()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
