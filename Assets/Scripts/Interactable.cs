using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool inRange;
    public UnityEvent interactAction;

    public enum InteractionType { ITEM, EVENT, NPC };

    public InteractionType type;
    

    public void Interaction()
    {
        switch (type)
        {
            case InteractionType.ITEM:
                GetComponent<Item>().pickUpItem();
                return;

            case InteractionType.NPC:
                Debug.Log(GetComponent<NPCObject>().npcName);
                return;
        }
    }
}