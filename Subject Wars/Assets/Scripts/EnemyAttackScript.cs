using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public int attackAmount = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Triggers when the unit collides with another unit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if it is an enemy unit
        if (collision.collider.gameObject.tag == "English")
        {
            //finds the enemy unit object and damages it
            collision.gameObject.GetComponent<UnitHealthScript>().TakeDamage(attackAmount);
        }
    }


    //Triggers when the unit enters inside of a towers box colliders
    void OnTriggerEnter2D(Collider2D col)
    {
        //checks to see if it is an enemy tower
        if (col.gameObject.tag == "English")
        {
            //finds the enemy tower object and damages it
            col.gameObject.GetComponent<TowerHandler>().TakeDamage(attackAmount);
        }

    }
}
