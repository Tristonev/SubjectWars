using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        if(transform.position.x < 24)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }
}
