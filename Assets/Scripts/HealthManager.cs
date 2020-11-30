using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    private bool isRespawning;
    public Vector3 respawnPoint;

    public PlayerMover thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        FindObjectOfType<GameManager>().AddHealth(maxHealth);
        respawnPoint = thePlayer.transform.position;
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
            respawn();
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
        thePlayer.transform.position = respawnPoint;
        currentHealth = maxHealth;
        GameObject player = GameObject.Find("Player");
        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        thePlayer.transform.position = respawnPoint;
        charController.enabled = true;
        FindObjectOfType<GameManager>().AddHealth(currentHealth);
    }
}
