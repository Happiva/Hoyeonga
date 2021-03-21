using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool inRange;
    public UnityEvent interactAction;

    public enum InteractionType { ITEM, EVENT };

    public InteractionType type;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (inRange)
        {            
            if (Input.GetButtonDown("Interaction"))
            {
                //이벤트 실행
                //interactAction.Invoke();
                Debug.Log("Interact");
                Interaction();
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("In Range");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Out Range");
            inRange = false;
        }
    }

    void Interaction()
    {
        switch (type)
        {
            case InteractionType.ITEM:
                GetComponent<Item>().pickUpItem();
                return;
        }
    }
}