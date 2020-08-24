using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDialogue : MonoBehaviour
{
    public GameObject Sign1;
    public Text sign1Text;
    private bool isInRange;
    public GameObject notification;

    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            notification.SetActive(false);
            Sign1.SetActive(true);
            sign1Text.text = "Welcome, Dr. Xavier. As you know, your mission is to exterminate the rogue fruit that have taken over our civilization." +
                " To help you with this task, the League of Doctors has equipped you with the quad-blade, a weapon consisting of four variants.";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Sign1.SetActive(false);
            }
        }
        if (isInRange == false)
        {
            Sign1.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
        if (collision.CompareTag("Player"))
        {
            if (isInRange == true)
            {
                notification.SetActive(true);

            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        if (collision.CompareTag("Player"))
        {
            if (isInRange == false)
            {
                notification.SetActive(false);
            }
        }
    }
}
