using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    [SerializeField] private float range;

    public LayerMask interactLayer;
    public Inventory inventory;
    public QuestManager questManager;

    void Update()
    {
        //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, interactLayer);

        /*
        if (hits.Length > 0)
        {            
            foreach (Collider2D collider in hits)
            { 
                //if (collider.)
            }                       
        }
        */

        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, interactLayer);

        if (hit != null)
        {
            if (Input.GetButtonDown("Interaction"))
            {
                hit.gameObject.GetComponent<Interactable>().Interaction();

                if (hit.gameObject.GetComponent<Interactable>().type == Interactable.InteractionType.NPC)
                {
                    questManager.CheckQuestProcess(hit.gameObject.GetComponent<NPCObject>().npcId);
                }                
            }
        }
        else
        {
            if (Input.GetButtonDown("Interaction"))
            {
                inventory.DropItem();
            }
        }
    }

    void OnDrawGizmosSelected()
    {      
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
