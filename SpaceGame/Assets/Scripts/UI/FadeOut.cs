using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour {

    

    public Image image;
    float T = 1.0f;

    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
    }

    private void Update()
    {

        Color c = image.color;
        int i = 255;
        if(i>0)
        {
            
            i--;
        }
        c.a = i;
        image.color = c;
    }



}
