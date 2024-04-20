using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

/* 
 * AdminBrowser is a class that is intended to handle the logic behind displaying the
 * locally saved user data to the admin. It implements the IStatTrack interface, 
 * and has 3 methods.
 */

public class AdminBrowser : MonoBehaviour, IStatTrack
{
    //GameObject that will hold each display object
    public GameObject listParent;

    //Prefab that holds the format to display data
    public GameObject dataText;
    
    //List that holds all displayed user objects
    private List<GameObject> userText;

    //Holds all saved game data
    private GameData gameObject;

    //iterator used for deletion
    private int i;

    //Start method triggers on the loading of the scene
    //Initializes list and iterator
    private void Start()
    {
        userText = new List<GameObject>();
        i = 0;
    }

    //DisplayUserData displays the user data by creating copies of the prefab assigning the data
    //Creates link from button clicks to DeleteUserData method
    public void DisplayUserData(GameData dataObject)
    {
        this.gameObject = dataObject;
        Debug.Log(dataObject);
        foreach (UserData obj in dataObject.users)
        {
            GameObject newText = Instantiate(dataText, listParent.transform);
            newText.GetComponent<StatDisplayText>().displayText.text = "User: " + obj.email + "  Wins: " + obj.winCount + "  Losses: " + obj.lossCount; //Huh?
            newText.GetComponent<StatDisplayText>().button.onClick.AddListener(() => DeleteUserData(obj.email));
            userText.Add(newText);
        }
    }

    //DeleteUserData is called by clicking the "x" button associated with a user
    //Iterates through the list of users until it finds the associated user to the button
    //User is removed from list and the main copy of the gameData is set
    public void DeleteUserData(string email)
    {
        i = 0;
        foreach (UserData obj in gameObject.users)
        {
            if (obj.email == email)
            {
                gameObject.users.Remove(obj);
                Debug.Log(email);
                GameObject.Find("DataPersistenceHandler").GetComponent<DataPersistenceManager>().setGameData(gameObject);
                break;
            }
            i++;
        }
    }

}
