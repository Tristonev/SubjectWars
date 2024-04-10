using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //imported unity engine scene manager for changing scenes when clicking buttons

public class MainMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("BaseLevel"); //The scene name is currently "SampleScene" since we have not worked on the level chooser yet. When the level choosing menu is done, SampleScene will be replaced by it.
    }

    public void Quit()
    {
        Application.Quit(); //Quits the application (closes the game).
    }

    public void Store()
    {
        SceneManager.LoadScene("Store"); //This will launch the store scene, which needs to be worked on still.
    }

}
