using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    //singleton class that allows its data to be retrieved publicly 
    public static DataPersistenceManager instance
    {
        get; private set;
    }

    //When program is opened, check to see if 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already a Data Persistence manager");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            Debug.Log(obj);
        }
        
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("New Game Created");
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            Debug.Log("No previous Data found");
            NewGame();
        }

        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(gameData);
        }

        Debug.Log("Loaded loss count = " + gameData.lossCount);
        Debug.Log("Loaded win count = " + gameData.winCount);
    }


    public void SaveGame()
    {
        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.SaveData(ref gameData);
        }

        Debug.Log("Saved loss count = " + gameData.lossCount);
        Debug.Log("Saved win count = " + gameData.winCount);

        dataHandler.Save(gameData);
    }

    private void OnQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
