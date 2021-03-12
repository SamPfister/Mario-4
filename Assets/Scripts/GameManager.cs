using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int currentGold;
    
    public Text goldText;
    public Text healthText;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Gold: " + PlayerPrefs.GetInt("totalCoins");
    }

    // Update is called once per frame
    void Update()
    {
        if((currentGold % 25) == 0)
        {
            PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") + 1);
            currentGold += 1;
            goldText.text = "Gold: " + currentGold;
            lifeText.text = "Lives: " + PlayerPrefs.GetInt("lives");
        }
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
