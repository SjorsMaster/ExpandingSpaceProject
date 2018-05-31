using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour {

    private bool Spawned;

    public string SceneName;

    void Update () {
        if (!Spawned)
        {
            Spawned = true;//Zorgt dat het niet spamt
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);//Laad win scene in
        }

    }
}
