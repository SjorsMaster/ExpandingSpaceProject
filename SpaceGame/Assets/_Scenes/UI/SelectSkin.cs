using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour {
    public void onClick(int SkinNumber)
    {
        PlayerPrefs.SetInt("Skin", SkinNumber);
    }

    void randomSkinner()
    {
        if (PlayerPrefs.GetInt("Skin") == 0)
        {
            //Animator
        }
        if (PlayerPrefs.GetInt("Skin") == 1)
        {
            //Animator
        }
        if (PlayerPrefs.GetInt("Skin") == 2)
        {
            //Animator
        }
        if (PlayerPrefs.GetInt("Skin") == 3)
        {
            //Animator
        }
    }
}
