using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int currentLives;
    public int maxHealth;
    private bool isRespawning;
    public Vector3 respawnPoint;
    public int sceneToLoad;
    public PlayerMover thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        FindObjectOfType<GameManager>().AddHealth(maxHealth);

        currentLives = PlayerPrefs.GetInt("lives");
        FindObjectOfType<GameManager>().AddLife(currentLives);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hurtPlayer(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            if(PlayerPrefs.GetInt("lives") > 0)
            {
                respawn();
            }
            else
            {
                gameOver();
            }   
        }

        else
        {
            FindObjectOfType<GameManager>().AddHealth(currentHealth);
        }
        
    }

    public void healPlayer(int healAmount)
    {
        currentHealth += healAmount;
        

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        FindObjectOfType<GameManager>().AddHealth(currentHealth);
    }

    public void respawn()
    {
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
        sceneToLoad = PlayerPrefs.GetInt("levelsCompleted") + 1;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void gameOver()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelsComplete", 2);
        PlayerPrefs.SetInt("lives", 5);
        PlayerPrefs.SetInt("totalCoins", 0);
    }
        
}
