using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleAttack : MonoBehaviour
{
    public playerHealth playerHealth;
    public int appleDamage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            playerHealth.TakeDamage(appleDamage);
        }
    }
}
