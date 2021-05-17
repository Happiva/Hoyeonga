using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public ItemDatabase items;

    private static Database instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Item_Scriptable GetItemById(int ID)
    {
        /*
        foreach (Item_Scriptable item in instance.items.allItems)
        {
            if (item.itemId == ID) return item;
        }

        return null;
        */
        return instance.items.allItems.FirstOrDefault(i => i.itemId == ID);
    }
}
