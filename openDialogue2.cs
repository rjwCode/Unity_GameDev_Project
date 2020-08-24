using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDialogue2 : MonoBehaviour
{
    public GameObject Sign2;
    public Text sign2Text;
    private bool isInRange;
    

    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            
            Sign2.SetActive(true);
            sign2Text.text = "Due to the high power usage of the weapon, a charging period is required after each attack. The quad-blade is charged when "
                + "the sword icon is blue.";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Sign2.SetActive(false);
            }
        }
        if (isInRange == false)
        {
            Sign2.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
        if (collision.CompareTag("Player"))
        {
            if (isInRange == true)
            {
                

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
                
            }
        }
    }
}
