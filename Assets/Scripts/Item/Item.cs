using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_Scriptable obj;

    public void pickUpItem()
    {
        Inventory inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (inven.getItem(obj))
            DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
