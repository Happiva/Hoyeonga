using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class NPC_Dambi : MonoBehaviour
{
    public Transform targetPosition;
    [SerializeField] private int speed;
    private Rigidbody2D rigid;

    private Animator animator;
    private PlayableDirector director;

    private bool isTrap;
    public GameObject log;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();

        isTrap = true;
    }

    
    void Update()
    {        
        if (!isTrap)
        { 
            animator.SetBool("isFree", true);
        }        
    }

    /*
    private void Move()
    {
        Collider2D hit = Physics2D.OverlapCircle(new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y), 0.2f, LayerMask.GetMask("Ground"));

        if (transform.position.x < targetPosition.position.x)
        {
            rigid.velocity = new Vector2(speed, 0);
        }

        if (hit != null)
        {
            rigid.AddForce(Vector3.up * 3f, ForceMode2D.Impulse);
        }
    }
    */

    void OnDrawGizmosSelected()
    {        
        Gizmos.DrawWireSphere(new Vector3(transform.localPosition.x + 0.25f, transform.localPosition.y), .2f);
    }

    public void FreeDambi()
    {
        isTrap = false;
    }

    public void PushLog()
    {
        this.transform.parent = log.transform;
    }
}
