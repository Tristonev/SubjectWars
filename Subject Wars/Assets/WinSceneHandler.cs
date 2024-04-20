using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneHandler : MonoBehaviour
{
    public void WinPlayAgain()
    {
        SceneManager.LoadScene("BaseLevel");
    }

    public void WinQuit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
