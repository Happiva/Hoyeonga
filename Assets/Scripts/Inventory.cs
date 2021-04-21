using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private Item_Scriptable item;

    public bool getItem(Item_Scriptable item)
    {
        if (this.item == null)
        {
            this.item = item;
            Debug.Log("You Got " + item.objectName);

            return true;
        }
        else return false;
    }

    public void dropItem()
    {
        if (item != null)
        {
            Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
            pos.x += 1f;
            Instantiate(item.prefab, pos, Quaternion.identity);
            item = null;
        }
        else
        {            
            Debug.Log("You don't have any items");
        }
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            dropItem();
        }
    }   
}
