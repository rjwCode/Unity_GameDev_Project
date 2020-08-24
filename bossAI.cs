using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAI : MonoBehaviour
{
    public BossHealth BH;
    public GameObject boss;
    public Transform player;
    public playerHealth playerHealth;
    public int playerDamage;
    public float moveSpeed;
    public GameObject flameTraps;
    public GameObject bulletPrefab;
    public Transform[] bulletPositions;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public float range;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
        
    }
    void Update()
    {
        range = Vector2.Distance(player.position, gameObject.transform.position);
        Debug.Log(range);
        if(BH.currentHealth <= 500 && BH.currentHealth > 400)
        {
            Chase();
        }
        else if(BH.currentHealth <= 400 && BH.currentHealth > 300)
        {
            if(timeBtwShots <= 0 && range <= 8 && range >= 1)
            {
                BulletCircle();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            Chase();
        }
        else if(BH.currentHealth <= 300 && BH.currentHealth > 200)
        {
            Chase();
            FlameTrap();
        }
        else if(BH.currentHealth <= 200 && BH.currentHealth > 0)
        {
            if (timeBtwShots <= 0)
            {
                BulletCircle();
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            Chase();
        }
    }

    public void FlameTrap()
    {
        
        flameTraps.SetActive(true);
        

    }
    void BulletCircle()
    {
        Instantiate(bulletPrefab, bulletPositions[0].position, Quaternion.identity);
        Instantiate(bulletPrefab, bulletPositions[1].position, Quaternion.identity);
        Instantiate(bulletPrefab, bulletPositions[2].position, Quaternion.identity);
        Instantiate(bulletPrefab, bulletPositions[3].position, Quaternion.identity);
    }
    void Chase()
    {
        boss.transform.position = Vector2.MoveTowards(boss.transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            playerHealth.TakeDamage(playerDamage);
        }
    }
}
