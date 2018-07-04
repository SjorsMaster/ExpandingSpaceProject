using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speedruntimer : MonoBehaviour
{
    public float PassedTime;
    private bool time;
    private string Scene;
    public Text Text;
    void Speedrunner()
    {
        time = true;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Updates();
    }

    private IEnumerator Updates()
    {
        if (time)
        {
            Text.text = "" + PassedTime;
            Scene = SceneManager.GetActiveScene().ToString();
            if (Scene != "Menu" || Scene != "Loading" || Scene != "Achievements" || Scene != "Preferences" || Scene != "Overworld" || Scene != "Reset")
            {
                PassedTime += Time.deltaTime;
            }
            else if (Scene == "Ending")
            {
                Text.text = "" + PassedTime;
                yield return new WaitForSeconds(1);
                Text.text = "";
                yield return new WaitForSeconds(0.2f);
                Text.text = "" + PassedTime;
                yield return new WaitForSeconds(1);
                Text.text = "";
                yield return new WaitForSeconds(0.2f);
                Text.text = "" + PassedTime;
                yield return new WaitForSeconds(1);
                Text.text = "";
                yield return new WaitForSeconds(0.2f);
                Text.text = "" + PassedTime;
                yield return new WaitForSeconds(1);
                if (PlayerPrefs.GetFloat("Speedrun", 10000000000000000000) > PassedTime)
                {
                    PlayerPrefs.SetFloat("Speedrun", PassedTime);
                    PlayerPrefs.SetString("SpeedrunName", PlayerPrefs.GetString("Player"));
                }
            }
        }
    }
}
