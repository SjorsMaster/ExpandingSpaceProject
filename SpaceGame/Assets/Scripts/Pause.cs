using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public GameObject[] canvasItems;
    bool trigger = true;

    private void Start()
    {
         Toggle(false);

    }

    private void Update()
    {
        
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log(Time.timeScale);
            if (trigger == true)
            {
                Time.timeScale = 0;
                Toggle(true);
                trigger = false;
            }
            else if (trigger == false) { 
                Time.timeScale = 1;
                Toggle(false);
                trigger = true;
            }
        }
    }

    void Toggle(bool state)
    {
        for (int i = 0; i < canvasItems.Length; i++)
        {
            canvasItems[i].SetActive(state);
        }
    }

    public void ButtonAction()
    {
        Time.timeScale = 1;
        Toggle(false);
        trigger = true;
    }

    //public void ButtonRemove()
    //{
    //    trigger = false;
    //    //Debug.Log("Button TRIGGER set: " + trigger);
    //    DestroyImmediate(canvasFind);
    //}

}
