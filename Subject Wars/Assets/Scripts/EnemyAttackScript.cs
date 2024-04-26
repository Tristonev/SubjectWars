using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackScript : MonoBehaviour
{
    public int attackAmount;

    public float attackSpeed;
    private float attackTimer = 0;



    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
    }

    //Triggers when the unit collides with another unit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checks to see if it is an enemy unit
        if (collision.collider.gameObject.tag == "English" && attackTimer <= 0)
        {
            //finds the enemy unit object and damages it
            collision.gameObject.GetComponent<UnitHealthScript>().TakeDamage(attackAmount);
            attackTimer = attackSpeed;
        }
    }


    //Triggers when the unit enters inside of a towers box colliders
    void OnTriggerEnter2D(Collider2D col)
    {
        //checks to see if it is an enemy tower
        if (col.gameObject.tag == "English" && attackTimer <= 0)
        {
            //finds the enemy tower object and damages i
            col.gameObject.GetComponent<TowerHandler>().TakeDamage(attackAmount, "English");
            attackTimer = attackSpeed;
        }

    }
}
