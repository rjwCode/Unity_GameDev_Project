using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class shootAndRetreat : MonoBehaviour
{
    public int moveSpeed;
    public int freezeSpeed;
    private int normalSpeed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        normalSpeed = moveSpeed;
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }

        if(timeBtwShots <= 0 && Vector2.Distance(transform.position, player.position) <= retreatDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
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
