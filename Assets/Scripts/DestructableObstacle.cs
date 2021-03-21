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


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        rigid = GetComponent<Rigidbody2D>();
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

        //파괴 애니메이션 있으면 넣기
        spriteRenderer.sprite = destroyedSp;       

        col.enabled = false;

        rigid.constraints = RigidbodyConstraints2D.None;
        Invoke("ObjectDestroy", .5f);
    }

    
    void ObjectDestroy() {
        Destroy(gameObject);
    }
    
}
