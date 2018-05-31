using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathTimer : MonoBehaviour {

    private bool Spawned;
    public float MaxTime;
    public string SceneName;//Scene naam kan worden meegegeven

    private float Timer;

    void Update () {
        Timer++;//Teld timer op

        if(Timer >= MaxTime && !Spawned)
        {
            Spawned = true;//Kijkt of al gespawned is
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);//Laad scene
        }
	}
}
