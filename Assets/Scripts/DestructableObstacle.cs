using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObstacle : MonoBehaviour
{
    public int objectHP;

    public Sprite destroyedSp;
    private SpriteRenderer spriteRenderer;

    private Collider2D col;
    private Rigidbody2D rigid;

    private Animator ani;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (objectHP == 0) {
            ObjectDestroyed();
        }
    }

    public void Damage(int damage) {
        objectHP -= damage;

        if (objectHP < 0) objectHP = 0;
    }

    
    void ObjectDestroyed() {

        /*
        spriteRenderer.sprite = destroyedSp;       

        col.enabled = false;

        rigid.constraints = RigidbodyConstraints2D.None;
        Invoke("ObjectDestroy", .5f);
        */

        ani.SetTrigger("IsDestroyed");
    }

    /*
    void ObjectDestroy() {
        Destroy(gameObject);
    }
    */
    
}
