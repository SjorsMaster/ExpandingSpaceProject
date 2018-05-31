using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFile : MonoBehaviour {
    public GameObject Object;

    private void Update()
    {
        Instantiate(Object);
    }
}
