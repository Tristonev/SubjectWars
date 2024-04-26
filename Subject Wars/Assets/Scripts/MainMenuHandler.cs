using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //imported unity engine scene manager for changing scenes when clicking buttons

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFade;

    public void Play()
    {
        screenFade.FadeToColor("BaseLevel"); //The scene name is currently "SampleScene" since we have not worked on the level chooser yet. When the level choosing menu is done, SampleScene will be replaced by it.
    }

    public void Quit()
    {
        Application.Quit(); //Quits the application (closes the game).
    }

    public void Login()
    {
        screenFade.FadeToColor("Login");
    }

    public void Admin()
    {
        screenFade.FadeToColor("AdminScene");
    }

}
