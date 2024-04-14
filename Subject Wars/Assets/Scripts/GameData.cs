using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class GameData
{
    public List<UserData> users;

    public GameData()
    {
        this.users = null;
    }
}

[System.Serializable]
public class UserData
{
    public string email;
    public int lossCount;
    public int winCount;

    //Whenever an object is created with this script, the win and loss values will be 
    public UserData(string email)
    {
        this.email = email;
        this.lossCount = 0;
        this.winCount = 0;
    }

    public UserData()
    {
        this.email = "";
        this.lossCount = 0;
        this.winCount = 0;
    }
}
