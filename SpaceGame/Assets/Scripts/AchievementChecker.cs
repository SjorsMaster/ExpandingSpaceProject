using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementChecker : MonoBehaviour
{
    public Text AchievementText;
    public string AchievementName;
    public string HowToGet;
    public string IfGotText;
    public bool AlsoCreateObject;
    public GameObject CreateObject;
    private int AchievementState;

    void Start()
    {
        AchievementState = PlayerPrefs.GetInt(AchievementName.Replace(" ", string.Empty), 0);

        if (AchievementState == 1)
        {
            AchievementText.text = AchievementName + ": \n" +  IfGotText;
            if (AlsoCreateObject)
            {
                Instantiate(CreateObject);
            }
        }
        else
        {
            AchievementText.text = AchievementName + ": \n" + HowToGet;
        }
    }
}
