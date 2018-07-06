using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel (string name)
    {
       PlayerPrefs.SetString("Level", name);
       SceneManager.LoadScene("Loading");
	}

    public void InstantLoad(string name)
    {
       SceneManager.LoadScene(name);    
    }

    public void RestartLevel()
    {
       string LevelReset = PlayerPrefs.GetString("StageRestart", "Menu");//Slaat stage op. anders menu
       PlayerPrefs.SetString("Level", LevelReset);//Geeft volgende level mee
       SceneManager.LoadScene("Loading");//Laad loading level    
    }

	public void QuitRequest()
    {
       Debug.Log("requist");
       Application.Quit();
	}
}