using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyScript : MonoBehaviour
{
    public bool hasKey;
    public int keyAmount;
    public Text keyCount;

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
        if (collision.CompareTag("Player"))
        {
            hasKey = true;
            keyAmount += 1;
            keyCount.text = "x " + keyAmount.ToString();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
