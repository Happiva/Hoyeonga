using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadCheck : MonoBehaviour
{
    public bool isSomethingOnHead;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            isSomethingOnHead = true;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        isSomethingOnHead = false;
    }
}
