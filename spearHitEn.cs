using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearHitEn : MonoBehaviour
{
    public appleHealth appleHealth;
    public pearHealth pearHealth;
    public playerHealth playerHealth;
    public int damage = 15;
    public patrolAndChase patrolAI;
    public shootAndRetreat shootAI;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            appleHealth.TakeDamage(damage);
            patrolAI.Freeze();
        }
        else if (collision.CompareTag("Pear"))
        {
            pearHealth.TakeDamage(damage);
            shootAI.Freeze();
        }
    }
}
