using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

/* 
 * FileDataHandler is a class that is intended to handle the saving,
 * and loading of all game data to a file. It has 1 contructor and 3 methods.
 */

public class FileDataHandler
{
    //Variable that holds the path to the saved file
    private string dirPath = "";
    //variable that holds the name of the file where data is saved
    private string dataFileName = "";

    //FileDataHandler is a constructor that initializes the given variables
    public FileDataHandler(string dirPath, string dataFileName)
    {
        this.dirPath = dirPath;
        this.dataFileName = dataFileName;
    }

    //LoadUsers is a method that opens the given file and attempts to read the json data
    //The json data is converted to a GameData object and returned to the caller
    public GameData LoadUsers()
    {
        string fullPath = Path.Combine(dirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                Debug.Log("File Exists");
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error on loading data from file" + fullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    //Save is a method that takes the given data and converts it to json data
    //The json data is then written to the set file
    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dirPath, dataFileName);

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError("Error on saving data to file" + fullPath + "\n" + e);
        }
    }

}
