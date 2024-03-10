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
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void ButtonClicked()
    {
        //adds a unit to the queue
        spawnCount++;
    }

}
