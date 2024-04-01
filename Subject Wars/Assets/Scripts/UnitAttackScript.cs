using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackScript : MonoBehaviour
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Math")
        {
            collision.gameObject.GetComponent<EnemyHealthScript>().TakeDamage(attackAmount);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Math")
        {
            col.gameObject.GetComponent<TowerHandler>().TakeDamage(attackAmount);
        }

    }

}