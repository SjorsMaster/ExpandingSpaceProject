using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnExist : MonoBehaviour {
    public string ObjectName;

	void Start () {
        if (GameObject.Find(ObjectName))
        {
            Destroy(this.gameObject);
        }
    }

}
