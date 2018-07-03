using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mountains : MonoBehaviour {
    
    public float Speed;
    public float yPos;
    public Transform player;//Locaties player

    private int Toggle;

    private void Start()
    {
        Toggle = PlayerPrefs.GetInt("TogglePalarax", 1);
    }

    void FixedUpdate () {
        if (Toggle == 1)
        {
            if (player)//Als speler bestaat
            {
                transform.position = new Vector2(player.position.x, yPos) * Speed;//Verplaats camera op speler x positie mee.
            }
        }
	}
}