using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item_Scriptable item;

    public bool GetItem(Item_Scriptable item)
    {
        if (this.item == null)
        {
            this.item = item;            

            return true;
        }
        else return false;
    }

    public void DropItem()
    {
        if (item != null)
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            Instantiate(item.prefab, pos, Quaternion.identity);
            item = null;
        }
    }

    public int GetItemId()
    {
        if (item != null)
            return item.itemId;

        else return -1;
    }

    public void ClearInventory()
    {
        item = null;
    }
}
