using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordChecker : MonoBehaviour {
    public Text text;
	void Start () {
        text.text = PlayerPrefs.GetString("Record", "No record yet.");
    }
}
