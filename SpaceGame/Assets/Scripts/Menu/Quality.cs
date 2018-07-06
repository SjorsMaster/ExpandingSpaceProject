using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quality : MonoBehaviour {

    public Slider sloof;

    void Update ()
    {
        if (Input.GetKeyDown("t"))
        {
            QualitySettings.SetQualityLevel(0, true);
        }
        if (Input.GetKeyDown("y"))
        {
            QualitySettings.SetQualityLevel(1, true);
        }
        if (Input.GetKeyDown("u"))
        {
            QualitySettings.SetQualityLevel(2, true);
        }
        if (Input.GetKeyDown("i"))
        {
            QualitySettings.SetQualityLevel(4, true);
        }
        if (Input.GetKeyDown("o"))
        {
            QualitySettings.SetQualityLevel(5, true);
        }
    }
}
