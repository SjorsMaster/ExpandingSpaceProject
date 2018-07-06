using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxChecker : MonoBehaviour {


    public string CheckName;
    public Toggle Checkbox;
    public bool Swap;
	// Use this for initialization
	void Start () {
        if (Swap)
        {
            PlayerPrefs.SetInt(CheckName, PlayerPrefs.GetInt(CheckName, 0));
        }
        if (PlayerPrefs.GetInt(CheckName, 1) == 1) {
            Checkbox.isOn = true;
        }
        else
        {
            Checkbox.isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Checkbox.isOn)
        {
            PlayerPrefs.SetInt(CheckName, 1);
        }
        else
        {
            PlayerPrefs.SetInt(CheckName, 0);
        }
    }
}
