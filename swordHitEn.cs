using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordHitEn : MonoBehaviour
{
    public appleHealth appleHealth;
    public pearHealth pearHealth;
    public playerHealth playerHealth;
    public int damage = 100;
    public int playerDamage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            appleHealth.TakeDamage(damage);
            playerHealth.TakeDamage(playerDamage);
        }
        if (collision.CompareTag("Pear"))
        {
            pearHealth.TakeDamage(damage);
            playerHealth.TakeDamage(damage);
        }
    }
}
