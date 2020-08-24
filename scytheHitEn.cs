using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class scytheHitEn : MonoBehaviour
{
    public appleHealth appleHealth;
    public pearHealth pearHealth;
    public playerHealth playerHealth;
    //public int damageAmnt = 30;
    //public int duration = 5;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            appleHealth.StartCoroutine(appleHealth.ScytheDamageOverTime(30, 5));
        }
        if (collision.CompareTag("Pear"))
        {
            pearHealth.StartCoroutine(pearHealth.ScytheDamageOverTime(30, 5));
        }
    }
}
