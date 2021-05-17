using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : MonoBehaviour
{
    public int npcId;
    public string npcName;

    //나중에 NPC 크기를 구분할 때 사용?
    public enum npcSize
    {
        NONE,
        SMALL,
        MIDDLE,
        BIG,
    }

    public npcSize size;
}
