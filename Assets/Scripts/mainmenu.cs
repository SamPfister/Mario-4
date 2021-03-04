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
	public int sceneToLoad;


	void OnMouseUp()
	{
		if (isNew)
		{
			// A new game overwrites any data from an existing game
			// There is only one save file at a time
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetInt("levelsComplete", 2);
			PlayerPrefs.SetInt("lives", 5);
			PlayerPrefs.SetInt("totalCoins", 0);
			SceneManager.LoadScene(1);
		}
        if (isResume)
        {
			sceneToLoad = PlayerPrefs.GetInt("levelsComplete") + 1;
			SceneManager.LoadScene(1);
		}
		if (isQuit)
		{
			Application.Quit();
		}
	}
}
