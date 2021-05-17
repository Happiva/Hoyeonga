using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public enum Prize
{
    HEALTH,
    EVENT,
    ITEM,
    NULL,
}

public enum Goal
{
    ITEM,
    INTERACTION,
}
public class Quest
{   
    public Prize prize;
    public Goal goal;

    public int questStartId;

    public int goalId;
    public int prizeItemId;

    public Quest(Prize prize, Goal goal, int questStartId, int goalId, int prizeItemId)
    {
        this.prize = prize;
        this.goal = goal;
        this.questStartId = questStartId;
        this.goalId = goalId;
        this.prizeItemId = prizeItemId;
    }

    public Quest(Prize prize, Goal goal, int questStartId, int goalId)
    {
        this.prize = prize;
        this.goal = goal;
        this.questStartId = questStartId;
        this.goalId = goalId;
        this.prizeItemId = -1;
    }
}

