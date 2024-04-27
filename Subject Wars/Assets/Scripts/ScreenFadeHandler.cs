using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFadeHandler : MonoBehaviour
{
    /* Reference to a black image that is used in the fader */
    [SerializeField] Image fader;

    /* Reference to the time that the fader will take */
    [SerializeField] float fadeTime = 1f;

    /* Reference to the color of fade */
    [SerializeField] Color fadeColor = Color.black;
    // Start is called before the first frame update
    void Start()
    {
        FadeToClear();
    }

    /* This function is called at the start of the script, will fade from black to transparent over the course of time through 
    * a coroutine */
    void FadeToClear()
    {
        fader.color = fadeColor;
        StartCoroutine(FadeToClearRoutine());
        IEnumerator FadeToClearRoutine()
        {
            float timer = 0;
            while(timer < fadeTime)
            {
                yield return null;
                timer += Time.deltaTime;
                fader.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, 1f - (timer/fadeTime));
            }
            fader.color = Color.clear;
        }
    }
    
    /* This function is called whenever a new scene must be loaded. The screen will fade to black, and proceed to load the next 
    * scene that is needed, passed to the function as a string */
    public void FadeToColor(string newScene = "")
    {
        fader.color = Color.clear;
        StartCoroutine(FadeToColorRoutine());
        IEnumerator FadeToColorRoutine()
        {
            float timer = 0;
            while(timer < fadeTime)
            {
                yield return null;
                timer += Time.deltaTime;
                fader.color = new Color(fadeColor.r, fadeColor.g, fadeColor.b, (timer/fadeTime));
            }
            fader.color = fadeColor;
            if(newScene != "")
            {
                SceneManager.LoadScene(newScene);
            }
        }
    }
}
