using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        if (transform.position.x > -8)
        {
            transform.Translate(transform.right * -speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Non-Trigger Colliders existing collision");

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger Colliders existing collision");
        //Destroy(gameObject);

    }
}
