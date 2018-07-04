using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOTDGrowShrink : MonoBehaviour {
    private bool one;
	
	// Update is called once per frame
	void Update () {

        if (!one)
        {
            transform.localScale += new Vector3(0.01F, 0, 0) / 35;
        }
        if (transform.localScale.x >= 0.18f)
        {
            one = true;
        }
        if (one)
        {
            transform.localScale -= new Vector3(0.01F, 0, 0) / 35;
        }
        if (transform.localScale.x <= 0.15f)
        {
            one = false;
        }
    }
}
