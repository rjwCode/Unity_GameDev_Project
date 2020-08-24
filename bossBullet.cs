using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    private playerHealth playerHealth;
    public int bulletDamage;
    private float lifeTime = 3f;
 



    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();

        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
    {

        target = new Vector2(player.position.x, player.position.y);

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        Destroy(gameObject, lifeTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletDamage);
            playerHealth.numOfHearts = playerHealth.currentHealth;
            DestroyProjectile();
            
        }
    }
}
