using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lossCount;
    public int winCount;

    //Whenever an object is created with this script, the win and loss values will be 
    public GameData()
    {
        this.lossCount = 0;
        this.winCount = 0;
    }
}
