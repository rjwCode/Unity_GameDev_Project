using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolAndChase : MonoBehaviour
{
    public int moveSpeed;
    public int freezeSpeed;
    private int normalSpeed;
    private float range;
    public Transform player;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private float waitTime;
    public float startWaitTime;
    
    void Start()
    {
        normalSpeed = moveSpeed;
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void Update()
    {
        range = Vector2.Distance(transform.position, player.position);
        ChaseAndRetreat();
        
    }

    void ChaseAndRetreat()
    {

        if (range <= 4 && range > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (range <= .9)
        {
            if(range < 4 && range >= .9)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, moveSpeed * Time.deltaTime);
                if (transform.position == moveSpot.position && waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
            if(range == 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }


        }
        else if (range >= 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, moveSpeed * Time.deltaTime);
            if (transform.position == moveSpot.position && waitTime <= 0)
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        
    }
   public IEnumerator FreezeEffect()
    {
        moveSpeed = freezeSpeed;
        yield return new WaitForSeconds(5f);
        moveSpeed = normalSpeed;
    }

    public void Freeze()
    {
        StartCoroutine(FreezeEffect());
    }
}
