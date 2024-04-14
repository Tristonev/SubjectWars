using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthScript : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    public Image HealthBar;

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

        HealthBar.fillAmount = currentHealth / maxHealth; //updates the health bar with the new hp

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
