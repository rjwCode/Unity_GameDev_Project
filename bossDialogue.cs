using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDialogue : MonoBehaviour
{
    public GameObject bossSign;
    public bool signIsUp = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossSign.SetActive(true);
            
            signIsUp = true;
        }
    }
    private void Update()
    {
        if(signIsUp == true && Input.GetKeyDown(KeyCode.E))
        {
            signIsUp = false;
            bossSign.SetActive(false);
            Destroy(gameObject);
        }

    }


}
