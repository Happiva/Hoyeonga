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
        Collider2D hit = Physics2D.OverlapCircle(transform.position, range, interactLayer);

        if (hit != null)
        {
            //Debug.Log(hit.gameObject.name);

            if (Input.GetButtonDown("Interaction"))
            {
                hit.gameObject.GetComponent<Interactable>().Interaction();

                if (hit.gameObject.GetComponent<Interactable>().type == Interactable.InteractionType.NPC)
                {
                    questManager.CheckQuestProcess(hit.gameObject);
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
