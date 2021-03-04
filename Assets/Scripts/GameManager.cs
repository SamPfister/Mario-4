using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentGold;
    
    public Text goldText;
    public Text healthText;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(int goldToAdd)
    {
        currentGold += goldToAdd;
        goldText.text = "Gold: " + currentGold;
    }

    public void AddHealth(int currentHealth)
    {
        healthText.text = "Health: " + currentHealth;
    }
    public void AddLife(int currentLives)
    {
        lifeText.text = "Lives: " + currentLives;
    }
}
