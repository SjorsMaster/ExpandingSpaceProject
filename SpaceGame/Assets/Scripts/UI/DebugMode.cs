using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour {
    
    public Text Position;
    public Text Scene;

    private string SceneName;
    private bool Debug;
    private bool GotScene;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();//Haal scene op.
        SceneName = scene.name;//Zet scene naam om naar string
    }
    
    void Update () {
        if (Input.GetKeyDown("`"))
        {
            Debug = true;//Zet debug menu aan.
        }
        if (Input.GetKeyDown("1"))
        {
            Debug = false;//Zet debug menu uit.
            Position.text = "";//Maakt leeg
            Scene.text = "";//Maakt leeg
        }
        if (Debug)//
        {
            Position.text = "Position: " + new Vector2(transform.position.x, transform.position.y);//Laat speler positie zien
            if (!GotScene)//Als scene nog niet opgehaald is
            {
                GetScene();//Haalt scene op
            }
        }
    }
    void GetScene()
    {
        GotScene = true;//Zorgt dat hij niet spamt
        Scene.text = "Scene: " + SceneName; //Plaats scene naam
    }
}
