using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //imported unity engine scene manager for changing scenes when clicking buttons

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFade;

    //ScreenFader will fade to black and load up the base level scene
    public void Play()
    {
        screenFade.FadeToColor("BaseLevel");
    }

    public void Quit()
    {
        Application.Quit(); //Quits the application (closes the game).
    }

    //ScreenFader will fade to black and load up the login scene
    public void Login()
    {
        screenFade.FadeToColor("Login");
    }

    //ScreenFader will fade to black and load up the login scene
    public void Admin()
    {
        screenFade.FadeToColor("AdminScene");
    }

}
