using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceHitEn : MonoBehaviour
{
    public appleHealth appleHealth;
    public pearHealth pearHealth;
    public playerHealth playerHealth;
    public int damage = 10;
    public int newHealth = 1;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            appleHealth.TakeDamage(damage);
            playerHealth.GainHealth(newHealth);
        }
        else if (collision.CompareTag("Pear"))
        {
            pearHealth.TakeDamage(damage);
            playerHealth.GainHealth(newHealth);
        }
    }
}
