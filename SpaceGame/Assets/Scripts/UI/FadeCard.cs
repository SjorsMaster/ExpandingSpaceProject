using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCard : MonoBehaviour {

    public float Alphalevel = 0f;
    public float speed = 1f;
    public GameObject card;

    // Update is called once per frame
    void Update() {

        GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, Alphalevel);
        add();
       }

       void add()
       {
           Alphalevel += 0.01f * speed;
       }
}
