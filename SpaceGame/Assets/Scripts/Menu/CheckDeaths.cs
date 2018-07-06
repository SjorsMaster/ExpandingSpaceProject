using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDeaths : MonoBehaviour {
    public Text text;

	// Use this for initialization
	void Start () {        
        text.text = "Total deaths: " + PlayerPrefs.GetInt("Strangeritual", 0);
	}
}
