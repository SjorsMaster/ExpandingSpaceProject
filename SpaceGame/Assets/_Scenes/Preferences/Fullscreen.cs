using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fullscreen : MonoBehaviour
{

    private bool FullScreenCheck;

    private void Update()
    {
        if (PlayerPrefs.GetInt("FullScreen", 0) == 0)
        {
            FullScreenCheck = false;
        }
        if (PlayerPrefs.GetInt("FullScreen", 0) == 1)
        {
            FullScreenCheck = true;
        }

        if (PlayerPrefs.GetInt("Resolution", 0) == 0)
        {
            Screen.SetResolution(960, 600, FullScreenCheck);
        }
        if (PlayerPrefs.GetInt("Resolution", 0) == 1)
        {
            Screen.SetResolution(858, 480, FullScreenCheck);
        }
        if (PlayerPrefs.GetInt("Resolution", 0) == 2)
        {
            Screen.SetResolution(1280, 720, FullScreenCheck);
        }
        if (PlayerPrefs.GetInt("Resolution", 0) == 3)
        {
            Screen.SetResolution(1920, 1080, FullScreenCheck);
        }
    }
}
