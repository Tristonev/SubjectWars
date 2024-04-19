using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AdminBrowser : MonoBehaviour, IStatTrack
{
    public GameObject listParent;
    public GameObject dataText;
    private List<GameObject> userText;
    private GameData gameObject;
    private int i;

    private void Start()
    {
        userText = new List<GameObject>();
        i = 0;
    }

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

    public void DeleteUserData(string email)
    {
        i = 0;
        foreach (UserData obj in gameObject.users)
        {
            if (obj.email == email)
            {
                //gameObject.users.RemoveAt(i);
                gameObject.users.Remove(obj);
                Debug.Log(email);
                GameObject.Find("DataPersistenceHandler").GetComponent<DataPersistenceManager>().setGameData(gameObject);
                break;
            }
            i++;
        }
    }

}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class AdminBrowser : MonoBehaviour, IStatTrack
{
    public GameObject listParent;
    public GameObject dataText;

    public void DisplayUserData(GameData dataObject)
    {
        Debug.Log(dataObject);
        foreach (UserData obj in dataObject.users)
        {
            GameObject newText = Instantiate(dataText, listParent.transform);
            newText.GetComponent<StatDisplayText>().displayText.text = "User: " + obj.email + "  Wins: " + obj.winCount + "  Losses: " + obj.lossCount; //Huh?
        }
    }

    private DataPersistenceManager FindAllDataPersistenceObjects()
    {
        DataPersistenceManager dataPersistenceObject = gameObject.GetComponent<DataPersistenceManager>();

        return (dataPersistenceObject);
    }

    public void DeleteUserData()
    {

    }
}

 */