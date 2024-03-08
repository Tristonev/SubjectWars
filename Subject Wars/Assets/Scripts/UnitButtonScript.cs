using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButtonScript : MonoBehaviour
{
    public GameObject unitObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnUnit()
    {
        var spawnerPos = GameObject.Find("Spawner").transform.position;
        Instantiate(unitObject, spawnerPos, Quaternion.identity);
    }

}
