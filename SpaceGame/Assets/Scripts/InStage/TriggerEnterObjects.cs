using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterObjects : MonoBehaviour {

    public GameObject other;
    public GameObject SpawnDust;

    private void Awake()
    {
    other = GameObject.Find("Achievement");
    }

    private void OnTriggerEnter2D()
    {

        if (PlayerPrefs.GetInt("Achievements", 1) == 1)
        {
            if (other.tag == "Achievement" && PlayerPrefs.GetInt("GetFucked", 0) != 2)
            {
                PlayerPrefs.SetInt("GetFucked", 1);
                if (PlayerPrefs.GetInt("Particles", 1) == 1){
                    Instantiate(SpawnDust, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                }
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "Achievement")
        {
            if (PlayerPrefs.GetInt("Particles", 1) == 1){
                Instantiate(SpawnDust, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
