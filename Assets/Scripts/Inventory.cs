using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<Item> items = new List<Item>();
    public Item items;

    public void getItem(Item item)
    {
        items = item;
        Debug.Log("You got " + item.name);
    }

    public void putDownItem(Item item)
    {
        
    }
}
