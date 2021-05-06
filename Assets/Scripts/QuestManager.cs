using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private int questId; //현재 퀘스트 아이디
    int questActionIndex;

    Dictionary<int, Quest> questList;   

    public Inventory inventory;
    public Player player;

    private void Awake()
    {
        questList = new Dictionary<int, Quest>();

        //첫 퀘스트 ID
        questId = 1001;
        GenerateData();
    }

    private void GenerateData()
    {
        //Prize, Goal, questStartId, goalId, prizeItemId
        questList.Add(1001, new Quest(Prize.HEALTH, Goal.ITEM, 1, 10001, -1));
    }

    public void CheckQuestProcess(int npcId)
    {
        //상호작용한 NPC가 Quest 의뢰 NPC
        if (npcId == questList[questId].questStartId)
        {
            //Quest 진척도를 확인함
            switch (questList[questId].goal)
            {                
                case Goal.ITEM:
                    if (inventory.GetItemId() == questList[questId].goalId)
                    {                        
                        Debug.Log("IMHERE");
                        //조건 만족 대사 출력하게                    
                        GetPrize();
                    }
                    else
                    {
                        //조건 불만족 대사 출력하게
                    }
                    break;

                case Goal.INTERACTION:
                    //if ()
                    break;
            }
        }
        //상호작용한 NPC가 Quest 의뢰 NPC가 아님.
        else
        { 
            //해당 NPC가 퀘스트 진행에 필요한 NPC인지 검사 후, 맞으면 퀘스트 진행시킴.
            //if (npcId == questList[questId].goalId)
        }
    }

    //목표를 수행했을 경우 실행, 보상을 주는 함수.
    public void GetPrize()
    {
        switch (questList[questId].prize)
        {
            case Prize.ITEM:
                Debug.Log("You got Item");                
                //Item에 대한 Database 함수 구현하면 id를 통해 아이템 찾아서 플레이어에게 줌.
                break;
            case Prize.HEALTH:
                Debug.Log("You get Health");
                //Player 컴포넌트 가져와서 Heal이나 Damage 수행.
                //어떤 때 힐, 어떤때 대미지를 수행할 수 있을지 정해야
                break;
            case Prize.EVENT:
                //좀 더 조사 필요
                break;
        }

        questId++;
    }
}
