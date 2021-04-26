using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public enum Prize
    { 
        HEALTH,
        EVENT,
        ITEM,
    }

    public enum Goal
    { 
        ITEM,
        INTERACTION,
    }

    public Prize prize;
    public Goal goal;

    public Item_Scriptable prizeItem;
}
