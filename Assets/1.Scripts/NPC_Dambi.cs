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
    public GameObject[] logs;

    public GameObject[] trigger;

    private GameObject player;

    private Vector3 offset;

    public TimelineAsset[] actionList;
    private int eventNum;
    private int logNum;
    private int triggerNum;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        director = GetComponent<PlayableDirector>();

        isTrap = true;
        movingLog = false;
        logNum = 0;
        eventNum = 0;
        triggerNum = 0;

        player = GameObject.FindGameObjectWithTag("Player");
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

        //Debug.Log(eventNum);
    }    

    public void FreeDambi()
    {
        isTrap = false;
    }

    public void PushLog()
    {
        //Debug.Log("Push log");
        transform.parent = logs[logNum].transform;
        movingLog = true;
        animator.SetBool("isMoving", true);
        
        offset = transform.localPosition;

        logs[logNum].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        logs[logNum].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == trigger[triggerNum])
        {
            //Debug.Log("Enter Trigger");
            offset = transform.position;
            transform.parent = null;
            transform.position = offset;
            NextEvent();
        }
    }

    private void NextEvent()
    {
        eventNum++;
        director.playableAsset = actionList[eventNum];
        director.Play();
    }

    private void NextLog()
    {
        //Debug.Log("Next Log!");
        logNum++;
    }

    private void NextTrigger()
    {
        triggerNum++;
    }

    public void StopDambi()
    {
        animator.SetBool("isMoving", false);
    }

    public void DisablePlayer()
    {
        player.SetActive(false);
    }

    public void ActivePlayer()
    {
        player.SetActive(true);
    }
}
