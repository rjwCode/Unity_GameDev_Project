using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UIElements;

public class appleHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public healthBarBehavior healthBar;
    public patrolAndChase patrolAI;
    public playerHealth playerHealth;

    public int maceDamage = 25;
    public int spearDamage = 30;
    public int swordDamage = 100;
    public int playerDamage = 7;

    private Material matWhite;
    private Material matDefault;
    private Material purpleDOT;
    SpriteRenderer sr;

    public AudioSource hitEffect;
    public AudioSource deathEffect;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth, maxHealth);

        //material stuff for flash
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        purpleDOT = Resources.Load("purpleDOT", typeof(Material)) as Material;
        matDefault = sr.material;
    }


    public void TakeDamage(int damage)
    {
        if(currentHealth > 0)
        {
            hitEffect.Play();
        }
        currentHealth -= damage;

        sr.material = matWhite;

        healthBar.SetHealth(currentHealth, maxHealth);
        

        if (currentHealth <= 0)
        {
            deathEffect.Play();
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", .25f);
        }

    }

    public IEnumerator ScytheDamageOverTime(int damageAmount, int duration)
    {
        int amountDamaged = 0;
        int damagePerLoop = damageAmount / duration;
        while(amountDamaged < damageAmount)
        {
            sr.material = purpleDOT;
            hitEffect.Play();
            currentHealth -= damagePerLoop;
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
        if(currentHealth <= 0)
        {
            deathEffect.Play();
            Destroy(gameObject);
        }
        else
        {
            Invoke("ResetMaterial", .25f);
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Mace")
        {
            TakeDamage(maceDamage);
            playerHealth.GainHealth(1);
        }
        else if (collision.collider.tag == "Scythe")
        {
            StartCoroutine(ScytheDamageOverTime(40, 5));
        }
        else if (collision.collider.tag == "Spear")
        {
            TakeDamage(spearDamage);
            patrolAI.Freeze();
        }
        else if (collision.collider.tag == "Sword")
        {
            TakeDamage(swordDamage);
            playerHealth.TakeDamage(playerDamage);
        }
    }
}
