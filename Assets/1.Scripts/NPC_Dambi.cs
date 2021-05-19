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
    private bool movingLog;
    public GameObject log;

    private Vector3 offset;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();

        isTrap = true;
        movingLog = false;
    }

    
    void Update()
    {        
        if (!isTrap)
        { 
            animator.SetBool("isFree", true);
        }
        
        if (movingLog)
        {
            transform.localPosition = offset;
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
        movingLog = true;
        animator.SetBool("isMoving", true);

        //offset = log.transform.position - this.transform.position;
        offset = this.transform.localPosition;

        log.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        log.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
