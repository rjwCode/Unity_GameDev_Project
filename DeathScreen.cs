using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public playerHealth playerHealth;
    public GameObject player;
    public GameObject deathScreen;

    
    private void Update()
    {
        if(playerHealth.playerIsDead == true)
        {
           
            Destroy(player);
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if(playerHealth.currentHealth > 0)
        {
            Time.timeScale = 1f;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

}
