using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	void Start () {
		if(PlayerPrefs.GetInt("AdventureOver",0) < 1)
        {
            Destroy(this.gameObject);
        }
	}
}
