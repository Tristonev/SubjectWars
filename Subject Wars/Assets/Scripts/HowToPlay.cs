using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{
    /* how to play pop up screen */
    [SerializeField] Canvas howToPlayCanvas;

    /* Opens the how to play canvas */
    public void OpenHowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    /* Closes the how to play canvas */
    public void CloseHowToPlay()
    {
        howToPlayCanvas.enabled = false;
    }
}
