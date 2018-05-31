using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceWin : MonoBehaviour {

	public void LoadLevel (){
        PlayerPrefs.SetString("Level", "Overworld");
        SceneManager.LoadScene("Loading");
	}


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LoadLevel();
        }
    }
}