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
        if (other.tag == "Achievement" && PlayerPrefs.GetInt("GetFucked", 0) != 2)
        {
            PlayerPrefs.SetInt("GetFucked", 1);
            Instantiate(SpawnDust, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (other.tag == "Achievement")
        {
            Instantiate(SpawnDust, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
