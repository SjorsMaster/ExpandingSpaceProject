using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VERSIONGETTER : MonoBehaviour {

    public Text Version;
    private string SaveVer;
    private string GameVer;

    void Start()
    {
        SaveVer = PlayerPrefs.GetString("SaveVer", Application.version);
        GameVer = Application.version;
        Version.text = "Ver: " + GameVer;

        if (SaveVer != GameVer) {
            PlayerPrefs.SetString("SaveVer", Application.version);
            SceneManager.LoadScene("Save_Err");
        }
        PlayerPrefs.SetString("SaveVer", Application.version);
    }
}
