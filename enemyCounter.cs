using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyCounter : MonoBehaviour
{
    public int enemiesLeft;
    public bool killedAllEnemies = false;
    public Text enemyCount;
    void Update()
    {
        GameObject[] appleEnemies = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] pearEnemies = GameObject.FindGameObjectsWithTag("Pear");
        enemiesLeft = appleEnemies.Length + pearEnemies.Length;
        enemyCount.text = "x " + enemiesLeft.ToString();
        
        if(enemiesLeft <= 0)
        {
            killedAllEnemies = true;
        }
    }
}
