using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

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

    public GameObject trigger;

    private Vector3 offset;

    public TimelineAsset[] actionList;

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
        
        offset = this.transform.localPosition;

        log.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        log.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trigger)
        {               
            offset = transform.position;
            this.transform.parent = null;
            transform.position = offset;
            director.playableAsset = actionList[1];
            director.Play();
        }
    }
}
