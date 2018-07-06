using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasterEggs : MonoBehaviour {
    public Text TextBox;
	// Use this for initialization
	void Start () {
        //Random message of the day
        int Randomizer = Random.Range(0,12);
        if (Randomizer == 0)
        {
            TextBox.text = "Play brilliant bob instead";
        }
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
        if (Randomizer == 6)
        {
            TextBox.text = "OOF";
        }
        if (Randomizer == 7)
        {
            TextBox.text = "Erwin is a terrible gamer";
        }
        if (Randomizer == 8)
        {
            TextBox.text = "Don't stop believing";
        }
        if (Randomizer == 9)
        {
            TextBox.text = "Potatoes are people too!";
        }
        if (Randomizer == 10)
        {
            TextBox.text = "No u";
        }
        if (Randomizer == 11)
        {
            TextBox.text = "Mamma mia!";
        }
        if (Randomizer == 12)
        {
            TextBox.text = "Spaaaaaaaaaaaaaceeeeeeee!";
        }
        if (System.DateTime.Now.Day.ToString() == "6" && System.DateTime.Now.Month.ToString() == "1")
        {
            TextBox.text = "Happy Birthday Sjors! :)";
        }
	}
}
