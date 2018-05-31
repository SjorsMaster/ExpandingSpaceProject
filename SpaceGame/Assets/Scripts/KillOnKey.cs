using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnKey : MonoBehaviour {
    
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Destroy(this.gameObject);
        }
	}
}
