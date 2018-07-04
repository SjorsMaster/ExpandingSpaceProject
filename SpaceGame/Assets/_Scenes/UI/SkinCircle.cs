using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinCircle : MonoBehaviour {

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;

	void Update ()
    {
        if (PlayerPrefs.GetInt("Skin", 0) == 0)
        {
            transform.position = new Vector2(s1.transform.position.x, s1.transform.position.y);
        }
        if (PlayerPrefs.GetInt("Skin", 0) == 1)
        {
            transform.position = new Vector2(s2.transform.position.x, s2.transform.position.y);
        }
        if (PlayerPrefs.GetInt("Skin", 0) == 2)
        {
            transform.position = new Vector2(s3.transform.position.x, s3.transform.position.y);
        }
        if (PlayerPrefs.GetInt("Skin", 0) == 3)
        {
            transform.position = new Vector2(s4.transform.position.x, s4.transform.position.y);
        }
    }
}
