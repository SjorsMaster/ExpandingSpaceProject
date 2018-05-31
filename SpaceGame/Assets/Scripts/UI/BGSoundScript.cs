/////////////////////////////////////////////////////////////
/////////////Youtube video gevolgd///////////////////////////
/////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGSoundScript : MonoBehaviour {

    //Play Global
    private static BGSoundScript instance = null;

    public string RemoveStage;
    public string RemoveStage2;
    string Level;

    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Level = SceneManager.GetActiveScene().name;
        if (RemoveStage == Level)
        {
            Destroy(this.gameObject);
        }
        if (RemoveStage2 == Level)
        {
            Destroy(this.gameObject);
        }
    }
}
