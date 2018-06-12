using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyV3 : MonoBehaviour {

    Animator m_Animator;

    public int Speed;
    public float rotation;
    public Transform Player;

    private bool flipped;
    private float Timer;
    private bool Over;
    private SpriteRenderer mySpriteRenderer;//<Shailesh??

    private void Start()
    {
        rotation = 180f;
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

        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        rotation = rotation + rotation;
        Debug.Log(rotation);

        transform.rotation = Quaternion.Euler(0, rotation, 0);


    }

}
