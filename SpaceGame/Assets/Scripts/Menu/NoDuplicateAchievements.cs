using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoDuplicateAchievements : MonoBehaviour {

    private bool Ready2Die;

	// Update is called once per frame
	void Update ()
    {
        if (SceneManager.GetActiveScene().ToString() == "Loading")
        {
            Ready2Die = true;
        }
        if (SceneManager.GetActiveScene().ToString() == "Menu" && Ready2Die)
        {
            Debug.Log("Oh no! I already exist! Bye bye.. You don't need me anymore.......");
            Destroy(this.gameObject);
        }
    }
}
