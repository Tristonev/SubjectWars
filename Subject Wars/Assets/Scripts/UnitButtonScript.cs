using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitButtonScript : MonoBehaviour
{
    public GameObject unitObject;
    public TMP_Text queueCount;
    private float spawnTimer = .5f;
    private int spawnCount = 0;

    public Text StarTextNumber; //currency text UI
    public Text Feedback;
    public int defaultCurrency; //default currency value
    public int currency; //current currency value

    //intialization
    public void Init() //Set up the currency value to the deafult currency and called UpdateUI() to show the default currency on screen
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    //update the text ui
    void UpdateUI()
    {
        StarTextNumber.text = currency.ToString();
    }

    public void gain(int val) //Method gain adds money, val passed in, to the currency variable if the currency is less than max currency, will also update the text on screen
    {
        if (currency < defaultCurrency)
        {
            currency += val;
            UpdateUI();
        }
    }


    //use currency
    public void use(int val) //Method uses money, val passed in, and updates text ui
    {
        currency -= val;
        UpdateUI();
    }

    //check for enough currency
    bool enoughCurrency(int val)
    {
        if (val <= currency)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        AddStars();
    }

    public void AddStars()
    {
        StartCoroutine(AddStarRoutine());
        IEnumerator AddStarRoutine()
        {
            WaitForSeconds waitTime = new WaitForSeconds(1f);
            while (true)
            {
                gain(1);
                UpdateUI();
                yield return waitTime;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AttemptSpawn();
    }

    void AttemptSpawn()
    {
        //This checks to see if the amount of time in spawnTimer has passed
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && spawnCount > 0)
        {
            //Spawns a unit and resets timer
            SpawnUnit();
            spawnTimer = .5f;
            spawnCount -= 1;
        }
    }


    public void SpawnUnit()
    {
        var spawnerPos = GameObject.Find("Spawner").transform.position;
        Instantiate(unitObject, spawnerPos, Quaternion.identity);
    }

    public void ButtonOneClicked() //Method to handle when the unit one button is clicked. Checks for enough currency, uses if there is enough and adds unit to spawn count.
    {
        if (enoughCurrency(3) == false)
        {
            //Debug.Log("Not enough stars");
            Feedback.text = "Not enough stars for unit one";
            return;
        }
        else
        {
            use(3);
            Feedback.text = "Used 3 stars for unit one";
            //adds a unit to the queue
            spawnCount++;
        }
    }

    public void ButtonTwoClicked() //Method to handle when the unit two button is clicked. Checks for enough currency, uses if there is enough and adds unit to spawn count.
    {
        if (enoughCurrency(4) == false)
        {
            //TO DO: show text of not enough currency
            //Debug.Log("Not enough stars");
            Feedback.text = "Not enough stars for unit two";
            return;
        }
        else
        {
            use(4);
            Feedback.text = "Used 4 stars for unit two";
            //adds a unit to the queue
            spawnCount++;
        }
    }

    public void ButtonThreeClicked() //Method to handle when the unit three button is clicked. Checks for enough currency, uses if there is enough and adds unit to spawn count.
    {
        if (enoughCurrency(6) == false)
        {
            //TO DO: show text of not enough currency
            //Debug.Log("Not enough stars");
            Feedback.text = "Not enough stars for unit three";
            return;
        }
        else
        {
            use(6);
            Feedback.text = "Used 6 stars for unit three";
            //adds a unit to the queue
            spawnCount++;
        }
    }

}
