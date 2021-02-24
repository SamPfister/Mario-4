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
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("levelsComplete", 0);
			PlayerPrefs.SetInt("lives", 0);
			PlayerPrefs.SetInt("totalCoins", 0);
			SceneManager.LoadScene(PlayerPrefs.GetInt("levelsComplete") + 1);
		}
        if (isResume)
        {
			int sceneToLoad = PlayerPrefs.GetInt("levelsComplete") + 1;
			SceneManager.LoadScene(sceneToLoad);
		}
		if (isQuit)
		{
			Application.Quit();
		}
	}
}
