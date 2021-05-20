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

    private GameObject interactNPC;

    private void Awake()
    {
        questList = new Dictionary<int, Quest>();

        //첫 퀘스트 ID
        questId = 1002;
        GenerateData();
    }

    private void GenerateData()
    {
        //Prize, Goal, questStartId, goalId, prizeItemId
        //추후에 json등의 데이터로 사용
        //questList.Add(1001, new Quest(Prize.ITEM, Goal.ITEM, 1, 10001, 10001));
        questList.Add(1002, new Quest(Prize.EVENT, Goal.ITEM, 2, 10001));
    }

    public void CheckQuestProcess(GameObject npc)
    {
        interactNPC = npc;

        //상호작용한 NPC가 Quest 의뢰 NPC
        if (npc.GetComponent<NPCObject>().npcId == questList[questId].questStartId)
        {
            //Quest 진척도를 확인함
            switch (questList[questId].goal)
            {                
                case Goal.ITEM:
                    if (inventory.GetItemId() == questList[questId].goalId)
                    {
                        //조건 만족 대사 출력하게
                        inventory.ClearInventory();
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
                inventory.GetItem(Database.GetItemById(questList[questId].prizeItemId));
                break;

            case Prize.HEALTH:
                Debug.Log("You get Health");
                //Player 컴포넌트 가져와서 Heal이나 Damage 수행.
                //어떤 때 힐, 어떤때 대미지를 수행할 수 있을지 정해야
                break;

            case Prize.EVENT:
                interactNPC.GetComponent<Interactable>().interactAction.Invoke();
                //Debug.Log("Event occured");

                break;
            case Prize.NULL:
                //아무 일 일어나지 않고 다음 퀘스트로 전환
                break;
        }

        questId++;
    }
}
