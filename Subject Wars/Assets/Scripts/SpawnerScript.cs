using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnerScript : MonoBehaviour
{
    //Unit types
    public GameObject addition;
    public GameObject division;
    public GameObject pi;

    //random spawn controls
    public float spawnTimer;
    private float spawnTime;

    //wave controls
    public float waveTimer;
    private float waveTime;
    private float waveSpawnDelay = .5f;
    private bool waveActive = false;
    private int curUnitNum = 1;

    // Start is called before the first frame update
    void Start()
    {
        waveTime = waveTimer;
    }

    // Update is called once per frame
    void Update()
    {
        AttemptSpawn();
    }

    private void AttemptSpawn()
    {
        //This checks to see if the amount of time in spawnTimer has passed
        spawnTime -= Time.deltaTime;

        waveTime -= Time.deltaTime;
        waveSpawnDelay -= Time.deltaTime;

        if(waveTime <= 0)
        {
            //Starts wave and resets wave timer
            waveActive = true;
            waveTime = waveTimer;
        }

        if (waveSpawnDelay <= 0 && waveActive)
        {
            //Spawns next unit in wave and resets the spawn delay
            SpawnWave();
            waveSpawnDelay = .5f;
        }

        //Spawns a random unit if spawn timer is up and no wave is currently active
        if (spawnTime <= 0 && !waveActive)
        {
            SpawnRandom();
        }
    }


    private void SpawnRandom()
    {
        int unitRoll = Random.Range(1, 20);

        //Spawns a unit based on the random number
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

        //resets the timer
        spawnTime = spawnTimer;
    }


    private void SpawnWave()
    {
        //Spawns the next unit in the wave
        //current pattern is : (add, add, pi) * 3 and then a division
        if (curUnitNum % 10 == 0)
        {
            Instantiate(division, transform.position, Quaternion.identity);
            waveActive = false;
            curUnitNum = 0;
            spawnTime = spawnTimer;
        }
        else if (curUnitNum % 3 == 0)
        {
            Instantiate(pi, transform.position, Quaternion.identity);
            curUnitNum++;
        }
        else
        {
            Instantiate(addition, transform.position, Quaternion.identity);
            curUnitNum++;
        }

    }


}
