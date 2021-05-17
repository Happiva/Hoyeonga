using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    public GameObject talkUI;

    private void Awake()
    {
        //대화 데이터 가져오게(Json)
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    private void GenerateData()
    {
        //퀘스트 : 1001~ / NPC : 1~
        //퀘스트 번호랑 NPC번호 검토할 필요 있음
        //쟤네를 더해서 Talk Data ID -> 해당 결과 없을 경우 NPC 통상 대화가 나오게? 혹은 아예 나오지 않게?
        talkData.Add(1, new string[] { "예시 NPC" });        
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
