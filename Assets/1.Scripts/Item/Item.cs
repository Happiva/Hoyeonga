using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item_Scriptable obj;

    public enum ItemObjType
    { 
        ITEM,
        ITEMGIVER,
    }

    public ItemObjType type;

    public void PickUpItem()
    {
        Inventory inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        if (inven.GetItem(obj) && this.type == ItemObjType.ITEM)
            Destroy(gameObject);
    }

    
}
