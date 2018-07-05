/////////////////////////////////////////////////////////////
/////////////Youtube video gevolgd///////////////////////////
/////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public string Stage;
    public bool ClickToSkip = true;
    public string AchievementName;
    public bool AlsoGiveAchievement = false;

    private string currentText = "";

    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && ClickToSkip || Input.GetMouseButtonDown(0) && ClickToSkip)
        {
            SceneManager.LoadScene(Stage);
            if (AlsoGiveAchievement)
            {
                PlayerPrefs.SetInt(AchievementName, 1);
            }
        }
    }
}
