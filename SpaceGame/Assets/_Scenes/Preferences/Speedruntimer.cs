using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Speedruntimer : MonoBehaviour
{
    public float PassedTime;
    private bool time;
    private Scene Scene;
    public Text Text;
public void press()
    {
        time = true;
    }
    private void Update()
    {
        if (time)
        {
            DontDestroyOnLoad(this.gameObject);
            PlayerPrefs.SetInt("Seen", 0);
            Text.text = "" + PassedTime.ToString("F2");
            Scene = SceneManager.GetActiveScene();
            if (Scene.name != "Loading" && Scene.name != "Achievements" && Scene.name != "Preferences" && Scene.name != "Overworld" && Scene.name != "Reset" && Scene.name != "Menu")
            {
                PassedTime += Time.deltaTime;
            }
            else if (Scene.name == "Ending")
            {
                Text.text = "" + PassedTime.ToString("F2");
                if (PlayerPrefs.GetFloat("Speedrun", 10000000000000000000) > PassedTime)
                {
                    PlayerPrefs.SetFloat("Speedrun", PassedTime);
                    PlayerPrefs.SetString("SpeedrunName", PlayerPrefs.GetString("Player","Player"));
                    PlayerPrefs.SetString("Record", "Current Record: " + PlayerPrefs.GetString("SpeedrunName", "error") + " - " + PlayerPrefs.GetFloat("Speedrun", 10000000000000000000) + " seconds.");
                }
            }
            if (PassedTime == 0)
            {
                Text.text = "Speedrun Ready";
            }
            if(Scene.name != "Menu" && PassedTime > 0.01f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
