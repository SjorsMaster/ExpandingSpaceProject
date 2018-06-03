using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour {

    public Text AchievementText;

    public Transform Starting;//AchievementPopupStart
    public Transform Ending;//AchievementPopupEind
    public float speed;//AchievementPopupSnelheid
    
    private float step;//AchievementPopupDeltatime

    public bool Got;//AchievementPopupTESTER
    public bool Reset;//AchievementPopupTESTER
                    //public float[] Achievement;
                    

   
    void Start()
    {
         step = speed * Time.deltaTime;
    }

    void Update () {
        ///string oof = PlayerPrefs.GetInt(Achievement[], 0);
        ///
        if(PlayerPrefs.GetInt("MoonJumper", 0) == 1000)
        {
            GoUp("MoonJumper");
        }

        if (Got)
        {
            if (PlayerPrefs.GetInt("MoonJumper", 0) != 2000)
            {
                PlayerPrefs.SetInt("MoonJumper", 1000);
            }
        }
        if (Reset)
        {
            PlayerPrefs.SetInt("MoonJumper", 0);
        }
    }

    void GoUp(string text)
    {
        StartCoroutine(PopUp());
        AchievementText.text = text;
    }

    IEnumerator PopUp()
    {
        transform.position = Vector3.MoveTowards(transform.position, Ending.position, step);
        yield return new WaitForSeconds(5);
        PopDown();
    }
    void PopDown()
    {
            PlayerPrefs.SetInt("MoonJumper", 2000);
        transform.position = Vector3.MoveTowards(transform.position, Starting.position, step);
    }
}
