using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class keyOpenDoor : MonoBehaviour
{
    public keyCollection key;
    public GameObject door;
    public bool canOpenDoor;


    private void Update()
    {
        if(canOpenDoor == true)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                Destroy(door);
                key.keyAmount -= 1;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(key.hasKey == true && key.keyAmount >= 1)
        {
            canOpenDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canOpenDoor = false;
    }
}
