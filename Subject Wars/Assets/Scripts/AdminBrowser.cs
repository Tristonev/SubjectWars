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
    public TextMeshProUGUI dataText;

    public void DisplayUserData(GameData dataObject)
    {
        Debug.Log(dataObject);
        foreach (UserData obj in dataObject.users)
        {
            TextMeshProUGUI newText = Instantiate(dataText, listParent.transform);
            GameObject.GetComponent<StatDisplayText>().displayText.text = obj.email; //Huh?
        }
    }

    private DataPersistenceManager FindAllDataPersistenceObjects()
    {
        DataPersistenceManager dataPersistenceObject = gameObject.GetComponent<DataPersistenceManager>();

        return (dataPersistenceObject);
    }
}

 */