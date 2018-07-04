using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour
{

    public Text AchievementText;
    public Text Skin;

    public Transform Starting;//AchievementPopupStart
    public Transform Ending;//AchievementPopupEind
    public float speed;//AchievementPopupSnelheid

    private float step;//AchievementPopupDeltatime

    private bool Active;
    //public bool Reset;//AchievementPopupTESTER
    //public float[] Achievement;
    bool go;
    bool WentTo;
    private int Timer;


    void Start()
    {
        step = speed * Time.deltaTime;
        Skin.text = "";
    }

    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("Achievements", 1) == 1)
            {
            if (PlayerPrefs.GetInt("MoonJumper", 0) == 100)
            {
                PlayerPrefs.SetInt("MoonJumper", 200);
                GoUp("Moon jumper");
            }
            if (PlayerPrefs.GetInt("Sowemeetagain", 0) == 1)
            {
                PlayerPrefs.SetInt("Sowemeetagain", 2);
                GoUp("So we meet again");
            }
            if (PlayerPrefs.GetInt("GetFucked", 0) == 1)
            {
                PlayerPrefs.SetInt("GetFucked", 2);
                GoUp("You're fucked");
            }
            if (PlayerPrefs.GetInt("HACKER", 0) == 1)
            {
                PlayerPrefs.SetInt("HACKER", 2);
                GoUp("Dirty hacker");
            }
            if (PlayerPrefs.GetInt("GottaGoFAST", 0) == 1)
            {
                PlayerPrefs.SetInt("GottaGoFAST", 2);
                Skin.text = "Blue skin unlocked!";
                GoUp("Gotta go FAST!");
            }
            if (PlayerPrefs.GetInt("Strangeritual", 0) == 666)
            {
                PlayerPrefs.SetInt("GottaGoFAST", 777);
                Skin.text = "Red skin unlocked!";
                GoUp("Strange ritual");
            }
            if (PlayerPrefs.GetInt("Collector", 0) == 100)
            {
                PlayerPrefs.SetInt("Collector", 200);
                GoUp("Collector");
            }
            if (PlayerPrefs.GetInt("Cheater", 0) == 1)
            {
                PlayerPrefs.SetInt("Cheater", 2);
                GoUp("Cheater");
            }
            /*if (Reset)
            {
                PlayerPrefs.SetInt("MoonJumper", 999);
            }*/



            if (Active)
            {
                Timer++;
                if(Timer >= 300)
                {
                    go = true;
                }

                if (transform.position != Ending.position && !go)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Ending.position, step);
                }
            }

            if (go)
            {
                transform.position = Vector3.MoveTowards(transform.position, Starting.position, step);
                if (transform.position == Starting.position || Timer >= 400)
                {
                    Active = false;
                    go = false;
                    Skin.text = "";
                    Timer = 0;
                }
            }
        }
    }

    void GoUp(string text)
    {
        AchievementText.text = text;
        Active = true;
    }
}