using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceRetry : MonoBehaviour {

    private Scene Level;//Slaat scene op

    private void Start()
    {
        Level = SceneManager.GetActiveScene();//Haalt huidige scene op
    }

    void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(Level.name);//Herlaad scene
        }
    }
}
