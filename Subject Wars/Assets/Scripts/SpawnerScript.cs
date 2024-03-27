using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
        //Instantiate(addition, transform.position, Quaternion.identity);

        //Instantiate(division, transform.position, Quaternion.identity);

        //Instantiate(pi, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        AttemptSpawn();
    }

    void AttemptSpawn()
    {
        //This checks to see if the amount of time in spawnTimer has passed
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            //Spawns a unit and resets timer
            Instantiate(addition, transform.position, Quaternion.identity);
            spawnTime = spawnTimer;
        }
    }

}
