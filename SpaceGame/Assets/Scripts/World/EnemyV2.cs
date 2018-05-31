using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV2 : MonoBehaviour {

    Animator m_Animator;

    public int Speed;
    public Transform Player;

    private bool flipped;
    private float Timer;
    private bool Over;
    private SpriteRenderer mySpriteRenderer;//<Shailesh??

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();//<Shailesh??
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update () {
            if (Player != null)//<Shailesh??
            {
                transform.Translate(Vector2.right * Speed * Time.deltaTime);//<Shailesh??
            }
            if(Player == null)
            {
            m_Animator.SetBool("Lach", true);
            }

        if (flipped)//Als omgedraait
        {
            Timer++;//Tel tijd op       
        }
        if (Timer >= 10)//Als tijd boven 10 MS zit
        {
            flipped = false;//Draaien false
            Timer = 0;//Timer terug zetten
        }
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        Speed = -Speed;//Draait beweging om

        if (!mySpriteRenderer.flipX && !flipped)
        {
            mySpriteRenderer.flipX = true;//Draait om
            flipped = true;//Zorgt dat er niet gespamt word
        }
        if (mySpriteRenderer.flipX && !flipped)
        {
            mySpriteRenderer.flipX = false;//Draait terug
            flipped = true;//Zorgt dat er niet gespamt word
        }

    }

}
