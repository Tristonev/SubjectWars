using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerScript : MonoBehaviour
{
    public GameObject addition;
    public GameObject division;
    public GameObject pi;

    private float spawnTimer = 4f;
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
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            //Spawns a unit and resets timer
            Instantiate(addition, transform.position, Quaternion.identity);
            spawnTimer = 4f;
        }
    }

}
