using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]

public class Item_Scriptable : ScriptableObject {

    public int itemId;
    public string objectName;
    public GameObject prefab;

    public enum ItemType
    { 
        COMSUMABLE,
        PICK,
        NONE
    }

    public ItemType itemType;
}
