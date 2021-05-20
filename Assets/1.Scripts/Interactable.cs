using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool inRange;
    public UnityEvent interactAction;

    public enum InteractionType { ITEM, EVENT, NPC, TRAP };

    public InteractionType type;
    

    public int Interaction()
    {
        switch (type)
        {
            case InteractionType.ITEM:
                GetComponent<Item>().PickUpItem();
                return GetComponent<Item>().obj.itemId;

            case InteractionType.NPC:
                return GetComponent<NPCObject>().npcId;

            case InteractionType.TRAP:
                GetComponent<Trap>().ReleaseTrap();
                return -1;
        }
        return 0;
    }
}