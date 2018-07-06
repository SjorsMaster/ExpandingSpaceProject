using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour {
    public InputField TextBox;
    private void Start()
    {
        TextBox.text ="Hi! " + PlayerPrefs.GetString("Player","Player");
    }
    void Update () {
        if (Input.GetKeyDown("return"))
        {
            PlayerPrefs.SetString("Player", TextBox.text);
            TextBox.text = "Hi! " + PlayerPrefs.GetString("Player", "Player");
        }
    }
}
