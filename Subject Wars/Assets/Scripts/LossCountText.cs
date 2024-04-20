using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * LossCountText is a class that handles the display of losses to the user on the main menu.
 * It has 4 methods.
 */

public class LossCountText : MonoBehaviour, IDataPersistence
{
    //Locally saved number of player losses
    private int lossCount = 0;

    //Object that displays the users loss count
    private TextMeshProUGUI lossCountText;

    //Awake method is called whenever this scene loads
    //The text object is assigned to its corresponding object
    private void Awake()
    {
        lossCountText = this.GetComponent<TextMeshProUGUI>();
        
    }

    //LoadData loads the data from the main copy of the game data to this class
    public void LoadData(UserData data)
    {
        this.lossCount = data.lossCount;

        if (StateDataController.losses == -1)
        {
            StateDataController.losses = this.lossCount;
        }

        if (this.lossCount != StateDataController.losses)
        {
            this.lossCount++;
            StateDataController.losses = this.lossCount;
        }
    }

    //SaveData class saves the data in this class to the main copy of the game data.
    public void SaveData(ref UserData data)
    {
        data.lossCount = this.lossCount;
    }


    //Update is called once per frame
    //Update method set text display to current number of wins
    private void Update()
    {
        lossCountText.text = "" + lossCount;
    }
}
