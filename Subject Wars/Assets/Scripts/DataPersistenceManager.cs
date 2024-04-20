using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

/* 
 * DataPersistenceManager is a class that is intended to act as a central system for
 * the creation, saving, and loading of all game data to one main area. It has 12 methods.
 */

public class DataPersistenceManager : MonoBehaviour
{
    //Holds file name
    //It is serializable to allow for storing the data.
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    //Stores the currents user data
    private UserData userData;

    //Stores all game data
    private GameData gameData;

    //List that holds win count and loss count text objects (They implement the IDataPersistence interface)
    private List<IDataPersistence> dataPersistenceObjects;

    //Holds the dataHandler that saves and loads data to the set file
    private FileDataHandler dataHandler;

    //Holds name of current scene
    private string sceneName;

    //Holds the admin view button
    public GameObject button;

    //singleton class that allows its data to be retrieved publicly 
    public static DataPersistenceManager instance
    {
        get; private set;
    }

    //Awake activates when the program is opened, check to see if there is another DataPersistenceManager in this scene
    //if there is noth, this is set as the main one
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is already a Data Persistence manager");
        }
        instance = this;
    }

    //Start activates when the scene is loaded
    //If admin is logged in on main menu, the admin button is activated
    //If admin is logged in admin view, the user data is displayed
    //Otherwise the current users data is loaded
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if ((sceneName == "MainMenu") && (StateDataController.email == "admin@gmail.com"))
        {
            button.SetActive(true);
        }

        if ((sceneName == "AdminScene") && (StateDataController.email == "admin@gmail.com"))
        {
            this.gameData = dataHandler.LoadUsers();
            IEnumerable<IStatTrack> adminTest = FindObjectsOfType<MonoBehaviour>().OfType<IStatTrack>();
            DisplayUsers(adminTest);
        }

        else if (StateDataController.email != "")
        {
            LoadUserData(StateDataController.email);
            LoadGame();
        }

    }

    //LoadUserData loads a given users data from the game data
    //If one is not found, a new user is created
    public void LoadUserData(string email)
    {
        this.gameData = dataHandler.LoadUsers();
        if (this.gameData == null)
        {
            Debug.Log("No previous Data found");
            NewGame();
            this.userData = null;
        }

        if (gameData.users != null)
        {
            foreach (UserData user in gameData.users)
            {
                if (user.email == email)
                {
                    this.userData = user;
                    StateDataController.email = user.email;

                }
            }
        } 
        else
        {
            this.gameData.users = new List<UserData>();
        }

            //Make new user
        if (this.userData == null)
        {
            NewUser(email);
        }

    }


    //NewGame initializes the gameData object
    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("New Game Created");
    }

    //NewUser initializes a new user and adds them to the gameData
    public void NewUser(string email)
    {
        this.userData = new UserData(email);
        this.gameData.users.Add(userData);
        Debug.Log("New User Created");

    }

    //LoadGame loads the current users saved data to the userData object
    public void LoadGame()
    {
        if (this.userData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(userData);
        }

    }

    //SaveGame goes through other local copies of usr data and updates
    //the main copy in this script. Then the main copy is saved to a file
    public void SaveGame()
    {
        if (StateDataController.email != "")
        {
            foreach (IDataPersistence obj in dataPersistenceObjects)
            {
                obj.SaveData(ref userData);
            }

            foreach (UserData user in gameData.users)
            {
                if (user.email == StateDataController.email)
                {
                    user.winCount = userData.winCount;
                    user.lossCount = userData.lossCount;
                }
            }

            dataHandler.Save(this.gameData);
        }
    }
   
    //DisplayUsers calls a method from a separate script that dislpays the user data
    public void DisplayUsers(IEnumerable<IStatTrack> adminTest)
    {
        foreach (IStatTrack obj in adminTest)
        {
            obj.DisplayUserData(gameData);
        }
        
    }

    //OnQuit saves the game when the user quits
    private void OnQuit()
    {
        SaveGame();
    }

    //getGameData is a getter method that allows outside callers to get the gameData
    public GameData getGameData()
    {
        return gameData;
    }

    //setGameData is a setter method that allows outside callers to set the gameData
    public void setGameData(GameData gameData)
    {
        this.gameData = gameData;
        dataHandler.Save(this.gameData);
    }

    //FindAllDataPersistenceObjects searches for all objects that implement IDataPersistence
    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
