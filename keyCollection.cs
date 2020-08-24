using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyCollection : MonoBehaviour
{
    public bool hasKey;
    public int keyAmount;
    public Text keyCount;
    public GameObject key;

    public AudioSource pickupKey;

    private void Start()
    {
        hasKey = false;
        
    }

    private void Update()
    {
        keyCount.text = "x " + keyAmount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            pickupKey.Play();
            hasKey = true;
            keyAmount += 1;
            keyCount.text = "x " + keyAmount.ToString();
            
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
