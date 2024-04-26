using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{

    [SerializeField] Canvas howToPlayCanvas;


    public void OpenHowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void CloseHowToPlay()
    {
        howToPlayCanvas.enabled = false;
    }
}
