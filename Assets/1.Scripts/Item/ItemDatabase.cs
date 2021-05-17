using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Asset/Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Item_Scriptable> allItems;
}
