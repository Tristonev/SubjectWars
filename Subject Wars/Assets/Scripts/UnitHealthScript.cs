using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealthScript : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Takes a damage amount from recieving an attack 
    //Reduces hp based on attack amount and kills the unit if it falls below 0
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
