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
    private bool waveActive = false;
    private bool smallWaveDone = false;
    private bool mediumWaveDone = false;
    private int curUnitNum = 1;
    private float waveTimer;
    private float waveSpawnDelay = .5f;

    //wave start times
    public float smallWaveTime;
    public float mediumWaveTime;
    public float largeWaveTime;


    // Start is called before the first frame update
    void Start()
    {
        waveTimer = smallWaveTime;
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

        waveTimer -= Time.deltaTime;
        waveSpawnDelay -= Time.deltaTime;

        if(waveTimer <= 0)
        {
            //Starts wave
            waveActive = true;
        }

        if (waveSpawnDelay <= 0 && waveActive)
        {
            //Spawns next unit in wave and resets the spawn delay
            if (!smallWaveDone)
            {
                SpawnSmallWave();
            }
            else if (!mediumWaveDone)
            {
                SpawnMediumWave();
            }
            else
            {
                SpawnLargeWave();
            }
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
        if (unitRoll <= 10 || !smallWaveDone)
        {
            Instantiate(addition, transform.position, Quaternion.identity);
        }
        else if (unitRoll <= 17 || !mediumWaveDone)
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

    private void SpawnSmallWave()
    {
        if (curUnitNum <= 3)
        {
            Instantiate(addition, transform.position, Quaternion.identity);
            curUnitNum++;
        }
        else
        {
            Instantiate(pi, transform.position, Quaternion.identity);
            //resets wave controls
            waveActive = false;
            curUnitNum = 1;
            smallWaveDone = true;
            //sets next wave timer and starts random spawns again
            waveTimer = mediumWaveTime - smallWaveTime;
            spawnTime = spawnTimer;
        }
    }

    private void SpawnMediumWave()
    {
        if (curUnitNum <= 2)
        {
            Instantiate(addition, transform.position, Quaternion.identity);
            curUnitNum++;
        }
        else if (curUnitNum <= 4)
        {
            Instantiate(pi, transform.position, Quaternion.identity);
            curUnitNum++;
        }
        else
        {
            Instantiate(division, transform.position, Quaternion.identity);
            //resets wave controls
            waveActive = false;
            curUnitNum = 1;
            mediumWaveDone = true;
            //sets next wave timer and starts random spawns again
            waveTimer = largeWaveTime - mediumWaveTime;
            spawnTime = spawnTimer;
        }
    }

    private void SpawnLargeWave()
    {
        //Spawns the next unit in the wave
        //current pattern is : (add, add, pi) * 3 and then a division
        if (curUnitNum % 10 == 0)
        {
            Instantiate(division, transform.position, Quaternion.identity);
            //resets wave controls and starts random spawns again
            waveActive = false;
            curUnitNum = 1;
            spawnTime = spawnTimer;
            waveTimer = largeWaveTime;
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
