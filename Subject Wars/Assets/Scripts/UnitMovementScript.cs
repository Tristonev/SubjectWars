using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovementScript : MonoBehaviour
{
    public float speed = 5;
    public float KBCounter;
    public float KBTotalTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (KBCounter <= 0)
        {
            //moves right until map end
            if (transform.position.x < 24)
            {
                transform.Translate(transform.right * speed * Time.deltaTime);
            }
        }
        else
        {
            //moves backwards for the time remaining in KBCounter
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }

        KBCounter -= Time.deltaTime;
    }

    //Triggers when the unit collides with another unit
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Non-Trigger Colliders existing collision");
        KBCounter = 0.25f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Colliders existing collision");

    }

}
