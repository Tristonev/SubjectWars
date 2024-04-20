using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * GameData is a class that holds a list of UserData.
 * It is serializable to allow for storing the data.
 * It has a constructor.
 */

[System.Serializable]
public class GameData
{
    public List<UserData> users;

    public GameData()
    {
        this.users = null;
    }
}

/*
 * UserData is a class that holds data for a user.
 * It is serializable to allow for storing the data.
 * It has a 2 constructors.
 */

[System.Serializable]
public class UserData
{
    //Stores user email
    public string email;
    
    //Stores users number of lost games
    public int lossCount;

    //Stores users number of wins
    public int winCount;

    //Whenever an object is created, the email, win, and loss values will be initialized
    public UserData(string email)
    {
        this.email = email;
        this.lossCount = 0;
        this.winCount = 0;
    }

    //Whenever an object is created withthout an email, the win and loss values will be initialized
    public UserData()
    {
        this.email = "";
        this.lossCount = 0;
        this.winCount = 0;
    }
}
