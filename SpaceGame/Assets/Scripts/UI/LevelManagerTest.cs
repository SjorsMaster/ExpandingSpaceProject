using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManagerTest : MonoBehaviour {

    bool loadstate = false;
    bool go = false;
    public Image LoadImage;
    public float TransitionSpeed = 0.25f;
    public float GoalAmmount = 1;

    public bool bLoadLevel = false;
    public bool bInstantLoad = false;
    public bool bRestartLevel = false;
    public bool bQuitRequest = false;

    public string StageName;

    public void LoadLevel (string nameLevel){
        StageName = nameLevel;
        Time.timeScale = 1;
        go = true;
        bLoadLevel = true;
    }

    public void InstantLoad(string nameLevel)
    {
        StageName = nameLevel;
        go = true;
        bInstantLoad = true;
    }

    public void RestartLevel()
    {
        go = true;
        bRestartLevel = true;
    }

	public void QuitRequest()
    {
        go = true;
        bQuitRequest = true;
	}

    void Update()
    {
        if (go)
        {
            LoadImage.fillAmount += 1.0f / TransitionSpeed * Time.deltaTime;
            if (LoadImage.fillAmount == GoalAmmount)
            {
                loadstate = true;
            }
        }
        if (loadstate)
        {
            if (bLoadLevel)
            {
                PlayerPrefs.SetString("Level", StageName);
                SceneManager.LoadScene("Loading");
            }
            else if (bInstantLoad)
            {
                SceneManager.LoadScene(StageName);
            }
            else if (bRestartLevel)
            {
                string LevelReset = PlayerPrefs.GetString("StageRestart", "Menu");//Slaat stage op. anders menu
                PlayerPrefs.SetString("Level", LevelReset);//Geeft volgende level mee
                SceneManager.LoadScene("Loading");//Laad loading level
            }
            else if (bQuitRequest)
            {
                Debug.Log("Lemme quit ;-;");
                Application.Quit();
            }
        }
    }
}