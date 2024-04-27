using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoginExit : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFader;
    
    //ScreenFader will fade to black and load up the main menu scene
    public void Exit()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
