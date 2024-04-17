using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerScript : MonoBehaviour
{
    public GameObject addition;
    public GameObject division;
    public GameObject pi;

    public float spawnTimer;
    private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AttemptSpawn();
    }

    public void AttemptSpawn()
    {
 

        //This checks to see if the amount of time in spawnTimer has passed
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            int unitRoll = Random.Range(1,20);

            //Spawns a unit and resets timer
            if (unitRoll <= 10)
            {
                Instantiate(addition, transform.position, Quaternion.identity);
            }
            else if (unitRoll <= 17)
            {
                Instantiate(pi, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(division, transform.position, Quaternion.identity);
            }

            spawnTime = spawnTimer;
        }
    }

}
