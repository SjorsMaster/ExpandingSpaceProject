using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnTime : MonoBehaviour {

    float Timer;
	
	// Update is called once per frame
	void Update () {
        Timer++;//Teld tijd op
        if(Timer >= 100)
        {
            Destroy(this.gameObject);//Verwijderd object na aantal seconden.
        }
    }
}
