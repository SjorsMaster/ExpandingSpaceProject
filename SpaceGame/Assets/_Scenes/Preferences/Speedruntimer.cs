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

    public void Speedrunner()
    {
        PlayerPrefs.SetInt("Seen", 0);
        time = true;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (time)
        {
            Text.text = "" + PassedTime.ToString("F2");
            Scene = SceneManager.GetActiveScene();
            Debug.Log(Scene);
            if (Scene.name != "Loading" && Scene.name != "Achievements" && Scene.name != "Preferences" && Scene.name != "Overworld" && Scene.name != "Reset")
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
            if(Scene.name != "Menu" && PassedTime > 0.01f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
