using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private UserData userData; //get rid of, or make list?
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;

    private FileDataHandler dataHandler;

    private string sceneName;
    private AdminBrowser admin;

    public GameObject button;
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
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            Debug.Log(obj);
        }

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
            Debug.Log("Email set");
            LoadUserData(StateDataController.email);
            LoadGame();
        }

        
        //LoadGame(); 
        //Load userdata then game when user logins or registers and login
    }

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

        //Debug.Log("Could not load user data from file");

        Debug.Log("Loaded loss count = " + userData.lossCount);
        Debug.Log("Loaded win count = " + userData.winCount);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        Debug.Log("New Game Created");
    }

    public void NewUser(string email)
    {
        this.userData = new UserData(email);
        this.gameData.users.Add(userData);
        Debug.Log("New User Created");

    }

    public void LoadGame()
    {
        //this.userData = dataHandler.Load(); //Take Out?
        if (this.userData == null)
        {
            Debug.Log("No previous Data found in Load Game");
            NewGame();
        }

        foreach (IDataPersistence obj in dataPersistenceObjects)
        {
            obj.LoadData(userData);
        }

        Debug.Log("Loaded loss count = " + userData.lossCount);
        Debug.Log("Loaded win count = " + userData.winCount);
    }


    public void SaveGame()
    {
        Debug.Log(StateDataController.email);
        if (StateDataController.email != "")
        {
            foreach (IDataPersistence obj in dataPersistenceObjects)
            {
                obj.SaveData(ref userData);
            }

            Debug.Log("Iterated Properly");

            foreach (UserData user in gameData.users)
            {
                if (user.email == StateDataController.email)
                {
                    user.winCount = userData.winCount;
                    user.lossCount = userData.lossCount;
                }
            }

            Debug.Log("Saved loss count = " + userData.lossCount);
            Debug.Log("Saved win count = " + userData.winCount);

            dataHandler.Save(this.gameData);
        }
    }
   
    public void DisplayUsers(IEnumerable<IStatTrack> adminTest)
    {
        foreach (IStatTrack obj in adminTest)
        {
            Debug.Log("In Display Users");
            Debug.Log(gameData);
            obj.DisplayUserData(gameData);
        }
        
    }

    private void OnQuit()
    {
        SaveGame();
    }

    public GameData getGameData()
    {
        return gameData;
    }

    public void setGameData(GameData gameData)
    {
        this.gameData = gameData;
        dataHandler.Save(this.gameData);
        Debug.Log("Set gameData");
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

}
