using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string Weekday = PlayerPrefs.GetString("Weekday", (System.DateTime.Now.DayOfWeek + 1).ToString());

        if (Weekday == (System.DateTime.Now.DayOfWeek - 6).ToString())
        {
            PlayerPrefs.SetInt("Sowemeetagain", 1);
        }
        PlayerPrefs.SetString("Weekday", (System.DateTime.Now.DayOfWeek + 1).ToString());

    }


    // Update is called once per frame
    void Update () {
		
	}
}
