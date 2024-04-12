using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerHandler : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;
    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        //sets tower to have max health at the start
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Trigger Colliders existing collision");

    }

    //Takes a damage amount from recieving an attack 
    //Reduces hp based on attack amount and destroys the tower if it is <= 0
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        HealthBar.fillAmount = currentHealth / maxHealth; //updates the health bar with the new hp

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

    }

}
