using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DebugScript : MonoBehaviour
{

    public InputField mainInputField;
    public Text Logs;
    public Text PlayerPOS;
    public GameObject TOOL;
    public GameObject PLAYER;
    public GameObject LoadLevel;
    private bool cheats;
    int inputC;
    int Speedor;
    private string stripped;

    public bool GodModus;
    public bool FlyModus;


    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            Instantiate(TOOL);
            Destroy(this.gameObject);
        }

        if (mainInputField.text.ToString().Contains("quit") && Input.GetKey(KeyCode.Return))
        {
            Application.Quit();
        }

        if (mainInputField.text.ToString().Contains("cheatm") && Input.GetKey(KeyCode.Return))
        {
            stripped = mainInputField.text.ToString().Replace("cheatm ", "");
            if (stripped == "true" || stripped == "1" || stripped == "on")
            {

                if (PlayerPrefs.GetInt("HACKER", 0) == 0)
                {
                    PlayerPrefs.SetInt("HACKER", 1);
                }

                cheats = true;
                Logs.text = "[" + System.DateTime.Now + "]:\n" + "Cheats are now active.\n";

            }
            else
            {
                cheats = false;
                Logs.text = "";
            }
        }

        if (cheats)
        {
            if (mainInputField.text.ToString().Contains("setspeed") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("setspeed ", "");
                Speedor = Int32.Parse(stripped);
                Time.timeScale = Speedor;
                if (Speedor > 100 || Speedor < 0)
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Error, Invalid value.\n" + Logs.text;
                }

            }

            else if (mainInputField.text.ToString().Contains("changelevel") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("changelevel ", "");
                if (Application.CanStreamedLevelBeLoaded(stripped))
                {
                    SceneManager.LoadScene(stripped);
                }
                else
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Error, The scene '" + stripped + "' can't be found. Try again.\n" + Logs.text;
                }

            }
            else if (mainInputField.text.ToString().Contains("spawn") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("spawn ", "");
                GameObject instance = Resources.Load(stripped, typeof(GameObject)) as GameObject;

                if (instance != null){
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Successfully spawned '" + stripped + "'.\n" + Logs.text;
                    Instantiate(instance);
                }
                else
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Error, Object '" + stripped + "' can't be found. Try again.\n" + Logs.text;
                }
            }

            else if (mainInputField.text.ToString().Contains("godmode") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("godmode ", "");
                if (stripped == "true" || stripped == "1" || stripped == "on")
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Godmode has been enabled.\n" + Logs.text;
                    FlyModus = true;
                }
                else
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Godmode now has been disabled.\n" + Logs.text;
                    FlyModus = false;
                }
            }
            else if (mainInputField.text.ToString().Contains("fly") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("fly ", "");
                if (stripped == "true" || stripped == "1" || stripped == "on")
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Fly now has been enabled.\n" + Logs.text;
                    FlyModus = true;
                }
                else
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Fly now has been disabled.\n" + Logs.text;
                    FlyModus = false;
                }
            }

            else
            {
                Logs.text = "[" + System.DateTime.Now + "]:\n" + "Unknown command.\n" + Logs.text;
            }

        }

        if (Input.GetKey(KeyCode.Return))
        {
            mainInputField.text = "";

        }
    }
}
