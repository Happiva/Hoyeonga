using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType { NONE, PICK, CONSUMABLES }

    public ItemType type;
    public string name;

    public void pickUpItem()
    {
        Inventory inven = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        inven.getItem(this);

        gameObject.SetActive(false);
    }
}
