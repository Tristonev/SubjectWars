using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HowToPlay : MonoBehaviour
{

    [SerializeField] Canvas howToPlayCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenHowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void CloseHowToPlay()
    {
        howToPlayCanvas.enabled = false;
    }
}
