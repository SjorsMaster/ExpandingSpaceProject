using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DEBUG : MonoBehaviour
{

    public InputField mainInputField;
    public Text Logs;
    public Text PlayerPOS;
    public GameObject TOOL;
    public GameObject PLAYER;
    public GameObject LoadLevel;
    private bool cheats;
    int inputC;
    private string stripped;
    private int skin;

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
                if (PlayerPrefs.GetInt("Cheater", 0) == 0)
                {
                    PlayerPrefs.SetInt("Cheater", 1);
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

            if (mainInputField.text.ToString().Contains("changelevel") && Input.GetKey(KeyCode.Return))
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
            if (mainInputField.text.ToString().Contains("setskin") && Input.GetKey(KeyCode.Return))
            {
                stripped = mainInputField.text.ToString().Replace("setskin ", "");
                skin = Int32.Parse(stripped);
                PlayerPrefs.SetInt("Skin", skin);
                Logs.text = "[" + System.DateTime.Now + "]:\n" + "Skin changed to skin " + skin + ".\n" + Logs.text;

                if (skin >= 4 || skin <= -1)
                {
                    Logs.text = "[" + System.DateTime.Now + "]:\n" + "Error, Skin not found.\n" + Logs.text;
                }

            }

            if (mainInputField.text.ToString().Contains("spawn") && Input.GetKey(KeyCode.Return))
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

            if (mainInputField.text.ToString().Contains("godmode") && Input.GetKey(KeyCode.Return))
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
            if (mainInputField.text.ToString().Contains("fly") && Input.GetKey(KeyCode.Return))
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

        }

        if (Input.GetKey(KeyCode.Return))
        {
            mainInputField.text = "";

        }
    }
}
