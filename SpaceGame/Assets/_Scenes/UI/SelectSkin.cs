using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSkin : MonoBehaviour {

    private Animator anim;
    public GameObject player;

    private void Start()
    {
        anim = player.GetComponent<Animator>();
    }

    private void Update()
    {
        randomSkinner();
    }

    public void onClick(int SkinNumber)
    {
        PlayerPrefs.SetInt("Skin", SkinNumber);
    }

    void randomSkinner()
    {
        if (PlayerPrefs.GetInt("Skin") == 0)
        {
            anim.SetInteger("Skin", 0);
        }
        if (PlayerPrefs.GetInt("Skin") == 1)
        {
            anim.SetInteger("Skin", 1);
        }
        if (PlayerPrefs.GetInt("Skin") == 2)
        {
            anim.SetInteger("Skin", 2);
        }
        if (PlayerPrefs.GetInt("Skin") == 3)
        {
            anim.SetInteger("Skin", 3);
        }
    }
}
