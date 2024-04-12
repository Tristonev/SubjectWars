using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoginExit : MonoBehaviour
{
    //This function will take you back to the main menu
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
