using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerTest : MonoBehaviour {

    bool loadstate = false;
    bool go = false;
    public Image LoadImage;
    public float TransitionSpeed = 1.0f;

    public void LoadLevel (string name){
        go = true;
        if (loadstate)
        {
            PlayerPrefs.SetString("Level", name);
            SceneManager.LoadScene("Loading");
        }
	}

    public void InstantLoad(string name)
    {
        go = true;
        if (loadstate)
        {
            SceneManager.LoadScene(name);
        }
    }

    public void RestartLevel()
    {
        go = true;
        if (loadstate)
        {
            string LevelReset = PlayerPrefs.GetString("StageRestart", "Menu");//Slaat stage op. anders menu
            PlayerPrefs.SetString("Level", LevelReset);//Geeft volgende level mee
            SceneManager.LoadScene("Loading");//Laad loading level
        }
    }

	public void QuitRequest(){
        go = true;
        if (loadstate)
        {
            Debug.Log("requist");
            Application.Quit();
        }
	}

    void Update()
    {
        if (go)
        {
            LoadImage.fillAmount -= 1.0f / TransitionSpeed * Time.deltaTime;
            if (LoadImage.fillAmount == 0)
            {
                Destroy(LoadImage);
                loadstate = true;
            }
        }
    }
}