using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

public class flameTrap : MonoBehaviour
{
    public playerHealth playerHealth;
    public int flameDamage;
    public BoxCollider2D Boss;
    public TilemapCollider2D flameCollider;

    private void Awake()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerHealth.TakeDamage(flameDamage);
        }
    }
    
}
