using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AchievementBar : MonoBehaviour {

    public Slider slider;
    public string achievement;
    public int ProgressBar;
    public float OutOf;

    void Update () {
        ProgressBar = PlayerPrefs.GetInt(achievement, 0);

        float progress = Mathf.Clamp01(ProgressBar / OutOf);//

        slider.value = progress;// tekenen
    }
	
}
