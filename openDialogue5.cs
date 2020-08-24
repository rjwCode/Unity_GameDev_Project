using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDialogue5 : MonoBehaviour
{
    public GameObject Sign5;
    public Text sign5Text;
    private bool isInRange;


    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {

            Sign5.SetActive(true);
            sign5Text.text = "Due to the high power usage of the weapon, a charging period is required after each attack. The quad-blade is charged when "
                + "the sword icon is blue.";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Sign5.SetActive(false);
            }
        }
        if (isInRange == false)
        {
            Sign5.SetActive(false);
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
