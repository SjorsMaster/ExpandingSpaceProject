using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDebug : MonoBehaviour {
    public GameObject MENU;
    // Update is called once per frame

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update () {
        if (Input.GetKeyDown("`"))
        {
            Instantiate(MENU);
            Destroy(this.gameObject);
        }
	}
}
