using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * IStatTrack is an interface that is intended to have the methods 
 * declared below used by an script that implements the interface.
 */

public interface IStatTrack
{
    //DisplayUserData displays the user data by creating copies of the prefab assigning the data
    //Creates link from button clicks to DeleteUserData method
    void DisplayUserData(GameData dataObject);
}
