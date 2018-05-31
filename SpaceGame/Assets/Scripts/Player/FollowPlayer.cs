using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer1 : MonoBehaviour {

    public Transform player;//Locaties player
	void Update () {
        if (player)//Als speler bestaat
        {
            transform.position = new Vector3(player.position.x, 0, 5);//Verplaats camera op speler x positie mee.
        }
        
	}
}