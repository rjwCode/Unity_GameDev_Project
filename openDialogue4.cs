using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDialogue4 : MonoBehaviour
{
    public GameObject Sign4;
    public Text sign4Text;
    private bool isInRange;


    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {

            Sign4.SetActive(true);
            sign4Text.text = "Pressing Z activates your quad-scythe, which attacks enemies on your left. The quad-scythe inflicts damage over time (indicated by the purple coloring of enemies). " +
                " Pressing V activates your quad-spear, which attacks enemies above you. The quad-spear inflicts moderate damage, but also freezes the " +
                "enemy for a short amount of time.";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Sign4.SetActive(false);
            }
        }
        if (isInRange == false)
        {
            Sign4.SetActive(false);
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
