using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivisionAttackScript : MonoBehaviour
{
    private int attackAmount;
    private float enemyHealth;

    public float attackSpeed;
    private float attackTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        attackAmount = 0;
    }

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
            //finds the enemy unit object and its current health
            enemyHealth = collision.gameObject.GetComponent<UnitHealthScript>().currentHealth;

            //Does either half the targets current health or 10, whichever is more
            attackAmount = (int)enemyHealth / 2;
            if (attackAmount > 10)
            {
                collision.gameObject.GetComponent<UnitHealthScript>().TakeDamage(attackAmount);
            }
            else
            {
                collision.gameObject.GetComponent<UnitHealthScript>().TakeDamage(10);
            }

            attackTimer = attackSpeed;
        }
    }


    //Triggers when the unit enters inside of a towers box colliders
    void OnTriggerEnter2D(Collider2D col)
    {
        //checks to see if it is an enemy tower
        if (col.gameObject.tag == "English" && attackTimer <= 0)
        {
            //finds the enemy tower object and its current health
            enemyHealth = col.gameObject.GetComponent<TowerHandler>().currentHealth;

            //Does either half the targets current health or 10, whichever is more
            attackAmount = (int)enemyHealth / 2;
            if (attackAmount > 10)
            {
                col.gameObject.GetComponent<TowerHandler>().TakeDamage(attackAmount, "English");
            }
            else
            {
                col.gameObject.GetComponent<TowerHandler>().TakeDamage(10, "English");
            }

            attackTimer = attackSpeed;
        }

    }
}