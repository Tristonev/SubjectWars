using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * WinCountText is a class that handles the display of wins to the user on the main menu.
 * It has 4 methods
 */

public class WinCountText : MonoBehaviour, IDataPersistence
{
    //Locally saved number of player wins
    private int winCount = 0;

    //Object that displays the users win count
    private TextMeshProUGUI winCountText;

    //Awake method is called whenever this scene loads
    //The text object is assigned to its corresponding object
    private void Awake()
    {
        winCountText = this.GetComponent<TextMeshProUGUI>();
        
    }

    //LoadData loads the data from the main copy of the game data to this class
    public void LoadData(UserData data)
    {
        this.winCount = data.winCount;
        if (StateDataController.wins == -1)
        {
            StateDataController.wins = this.winCount;
        }

        else if (this.winCount < StateDataController.wins)
        {
            this.winCount++;
            StateDataController.wins = this.winCount;
        }
    }

    //SaveData class saves the data in this class to the main copy of the game data.
    public void SaveData(ref UserData data)
    {
        data.winCount = this.winCount;
    }

    //Update is called once per frame
    //Update method set text display to current number of wins
    private void Update()
    {
        winCountText.text = "" + winCount;
    }
}
