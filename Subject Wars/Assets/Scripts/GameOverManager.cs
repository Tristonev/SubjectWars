using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] ScreenFadeHandler screenFader;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        screenFader.FadeToColor("BaseLevel");
    }

    public void QuitGame()
    {
        screenFader.FadeToColor("MainMenu");
    }
}
