using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInteraction : MonoBehaviour
{
    [SerializeField] private float range;

    public LayerMask interactLayer;

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
            }
        }                    
    }

    void OnDrawGizmosSelected()
    {      
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
