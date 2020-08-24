using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 500;
    public int currentHealth;
    public playerHealth playerHealth;
    public bossAI bossAi;
    

    private Material matWhite;
    private Material matDefault;
    private Material purpleDOT;
    SpriteRenderer sr;

    public int maceDamage = 25;
    public int spearDamage = 30;
    public int swordDamage = 100;
    public int playerDamage = 5;

    public AudioSource hitEffect;
    public AudioSource deathEffect;

    public bossHealthbar bossHealthbar;
    public GameObject healthbar;
    public GameObject winScreen;




    void Start()
    {

        currentHealth = maxHealth;
        bossHealthbar.SetMaxHealth(maxHealth);

        //material stuff for flash
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        purpleDOT = Resources.Load("purpleDOT", typeof(Material)) as Material;
        matDefault = sr.material;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            deathEffect.Play();
            healthbar.SetActive(false);
            Destroy(gameObject);
            winScreen.SetActive(true);

        }
    }

    public void TakeDamage(int damage)
    {
        hitEffect.Play();

        currentHealth -= damage;

        bossHealthbar.SetHealth(currentHealth);

        sr.material = matWhite;



        if (currentHealth <= 0)
        {
            deathEffect.Play();
            healthbar.SetActive(false);
            Destroy(gameObject);
            winScreen.SetActive(true);

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
        bossHealthbar.SetHealth(currentHealth);
        while (amountDamaged < damageAmount)
        {
            hitEffect.Play();
            sr.material = purpleDOT;
            currentHealth -= damagePerLoop;
            amountDamaged += damagePerLoop;
            yield return new WaitForSeconds(1f);
        }
        if (currentHealth <= 0)
        {
            deathEffect.Play();
            healthbar.SetActive(false);
            Destroy(gameObject);
            winScreen.SetActive(true);

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

        }
        else if (collision.collider.tag == "Sword")
        {
            TakeDamage(swordDamage);
            playerHealth.TakeDamage(playerDamage);
        }
    }
}


