using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour
{
    private BoxCollider2D collider;
    private Rigidbody2D rigid;
    private Animator ani;
    public GameObject dust;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.SetBool("Broke", true);            
        }

        if (collision.gameObject.tag == "Ground")
        {            
            //rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            //rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            dust.GetComponent<Animator>().SetTrigger("Play");
        }
    }

    void Drop()
    {
        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
