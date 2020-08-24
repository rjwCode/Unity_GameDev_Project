using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openDialogue3 : MonoBehaviour
{
    public GameObject Sign3;
    public Text sign3Text;
    private bool isInRange;


    private void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {

            Sign3.SetActive(true);
            sign3Text.text = "Pressing C will activate your quad mace, which attacks enemies on your right side. The mace does light damage," +
                " yet heals you for each hit landed. Pressing X will activate your quad sword, which attacks enemies below you. This does critical" +
                " damage, but hurts you as well.";
            if (Input.GetKeyDown(KeyCode.B))
            {
                Sign3.SetActive(false);
            }
        }
        if (isInRange == false)
        {
            Sign3.SetActive(false);
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
