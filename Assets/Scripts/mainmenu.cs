using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    public bool isResume;
	public bool isNew;
    public bool isQuit;
	void OnMouseUp()
	{
		if (isNew)
		{
			// A new game overwrites any data from an existing game
			// There is only one save file at a time
			PlayerPrefs.SetInt("levelsComplete", 0);
			PlayerPrefs.SetInt("lives", 0);
			PlayerPrefs.SetInt("totalCoins", 0);
			Application.LoadLevel(PlayerPrefs.GetInt("levelsComplete") + 1);
		}
        if (isResume)
        {
			Application.LoadLevel(PlayerPrefs.GetInt("levelsComplete") + 1);
		}
		if (isQuit)
		{
			Application.Quit();
		}
	}
}
