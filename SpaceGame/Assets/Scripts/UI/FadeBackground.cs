using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBackground : MonoBehaviour {

    public float Alphalevel = 0f;
    public bool flip;
    public float speed = 1f;

    private int Toggle;

    private void Start()
    {
        Toggle = PlayerPrefs.GetInt("ToggleStars", 1);
    }

    // Update is called once per frame
    void Update() {
        if (Toggle == 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, Alphalevel);

            if (!flip)
            {
                count();
            }
            if (Alphalevel < 0f)
            {
                flip = true;
            }
            if (flip)
            {
                add();
            }
            if (Alphalevel > 1f)
            {
                flip = false;
            }
        }
       }

       void add()
       {
           Alphalevel += 0.01f * speed;
       }

       void count()
       {
           Alphalevel -= 0.01f * speed;
       }


}
