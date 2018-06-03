using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggs : MonoBehaviour {
    public Text TextBox;
	// Use this for initialization
	void Start () {
        //Random message of the day
        int Randomizer = Random.Range(0,6);
        if (Randomizer == 1)
        {
            TextBox.text = "I'm bored";
        }
        if (Randomizer == 2)
        {
            TextBox.text = "Good to see you again!";
        }
        if (Randomizer == 3)
        {
            TextBox.text = "I wonder whats for dinner!";
        }
        if (Randomizer == 4)
        {
            TextBox.text = "Welcome to my schoolhouse!";
        }
        if (Randomizer == 5)
        {
            TextBox.text = "Do I know you?";
        }
        if (System.DateTime.Now.Day.ToString() == "6" && System.DateTime.Now.Month.ToString() == "1")
        {
            TextBox.text = "Happy Birthday Sjors! :)";
        }
	}
}
