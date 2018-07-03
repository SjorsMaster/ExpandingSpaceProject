using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheater : MonoBehaviour {

    public Text oof;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log(PlayerPrefs.GetInt("Cheater", 0));
    }
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("Cheater", 0) >= 1)
        {
            oof.text = "CHEATER";
        }
    }
}
