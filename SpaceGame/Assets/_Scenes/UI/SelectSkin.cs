using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour {
    public void onClick(int SkinNumber)
    {
        PlayerPrefs.SetInt("Skin", SkinNumber);
    }
}
