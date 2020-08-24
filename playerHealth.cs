using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public Text healthText;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public bool playerIsDead = false;

    public AudioSource gainHP;
    public AudioSource hit;
    public AudioSource dead;
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        numOfHearts = currentHealth;
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(currentHealth <= 0)
        {
            dead.Play();
            playerIsDead = true;

        }
    }
    public void TakeDamage(int damage)
    {
        hit.Play();
        currentHealth -= damage;
        numOfHearts = currentHealth;
    }

    public void GainHealth(int newHealth)
    {
        gainHP.Play();
        currentHealth += newHealth;
        numOfHearts = currentHealth;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
