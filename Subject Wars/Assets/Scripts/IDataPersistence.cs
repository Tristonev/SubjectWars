using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * IDataPersistence is an interface that is intended to have the methods 
 * declared below used by an script that implements the interface.
 */

public interface IDataPersistence
{
    //LoadData loads the data from the main copy of the game data to this class
    void LoadData(UserData data);

    //SaveData class saves the data in this class to the main copy of the game data.
    void SaveData(ref UserData data);

}
