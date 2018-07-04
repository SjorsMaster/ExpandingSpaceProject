using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resolution : MonoBehaviour {

    private bool FullScreenCheck;
    public Dropdown Valuer;

    private void Update()
    {
        if (PlayerPrefs.GetInt("FullScreen", 0) == 0)
        {
            FullScreenCheck = false;
        }else{
            FullScreenCheck = true;
        }

        if (Valuer.value == 0 || PlayerPrefs.GetInt("Resolution", 0) == 0)
        {
            PlayerPrefs.SetInt("Resolution", 0);
            SetRes(960, 600);
        }
        if (Valuer.value == 1 || PlayerPrefs.GetInt("Resolution", 0) == 1)
        {
            PlayerPrefs.SetInt("Resolution", 1);
            SetRes(858, 480);
        }
        if (Valuer.value == 2 || PlayerPrefs.GetInt("Resolution", 0) == 2)
        {
            PlayerPrefs.SetInt("Resolution", 2);
            SetRes(1280, 720);
        }
        if (Valuer.value == 3 || PlayerPrefs.GetInt("Resolution", 0) == 3)
        {
            PlayerPrefs.SetInt("Resolution", 3);
            SetRes(1920, 1080);
        }
    }

    public void SetRes(int a,int b)
    {
        Screen.SetResolution(a, b, FullScreenCheck);
    }
    
}
