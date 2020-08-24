using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject upSword;
    public GameObject leftSword;
    public GameObject rightSword;
    public GameObject downSword;
    private float waitTime;
    public float startWaitTime;
    private bool hasAttacked;
    public Image canAttackUI;
    public AudioSource bladeCharged;
    private void Start()
    {
        waitTime = startWaitTime;
        hasAttacked = false;
        canAttackUI.color = new Color(0, 0, 255, 255);
    }
    private void Update()
    {
        StartCoroutine(AttackWithSword());
    }
    IEnumerator AttackWithSword()
    {
        if (hasAttacked == false)
        {
            

            if (Input.GetKeyDown(KeyCode.V) && waitTime <= 0)
            {

                upSword.SetActive(true);
                yield return new WaitForSeconds(.1f);
                upSword.SetActive(false);
                hasAttacked = true;
                canAttackUI.color = new Color(255, 255, 255, 255);

            }

            else if (Input.GetKeyDown(KeyCode.Z) && waitTime <= 0)
            {
                leftSword.SetActive(true);
                yield return new WaitForSeconds(.1f);
                leftSword.SetActive(false);
                hasAttacked = true;
                canAttackUI.color = new Color(255, 255, 255, 255);
            }


            else if (Input.GetKeyDown(KeyCode.X) && waitTime <= 0)
            {

                downSword.SetActive(true);
                yield return new WaitForSeconds(.1f);
                downSword.SetActive(false);
                hasAttacked = true;
                canAttackUI.color = new Color(255, 255, 255, 255);
            }

            else if (Input.GetKeyDown(KeyCode.C) && waitTime <= 0)
            {

                rightSword.SetActive(true);
                yield return new WaitForSeconds(.1f);
                rightSword.SetActive(false);
                hasAttacked = true;
                canAttackUI.color = new Color(255, 255, 255, 255);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (hasAttacked == true)
        {
            
            this.enabled = false;
            yield return new WaitForSeconds(2f);
            this.enabled = true;
            hasAttacked = false;
            canAttackUI.color = new Color(0, 0, 255, 255);
            bladeCharged.Play();
        }
        
        
    }
}
