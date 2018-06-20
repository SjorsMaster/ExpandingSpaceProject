using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Image fadein;
    public float TransitionSpeed;

    private void Update()
    {
        fadein.fillAmount -= 1.0f / TransitionSpeed* Time.deltaTime;

        if (fadein.fillAmount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
