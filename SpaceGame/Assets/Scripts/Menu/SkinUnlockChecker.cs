using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinUnlockChecker : MonoBehaviour {

    public string AchievementName;
    public int MinimumRequirement;
    public Button button;
    public Text text;
    public int buttonid;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt(AchievementName,0) >= MinimumRequirement)
        {
            text.text = "" + buttonid;
            button.interactable = true;
        }
        else
        {
            text.text = "?";
            button.interactable = false;
        }
	}
}
