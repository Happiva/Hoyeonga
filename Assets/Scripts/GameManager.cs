using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Player가 움직일 수 있는지, 아닌지 관리
    public bool canAction;

    private static GameManager instance;
    public Vector2 lastCheckPoint;

    [Header("Managers")]
    public TalkManager talkManager;
    public GameObject talkUI;
    public TextMeshProUGUI talkText;
    public int talkIndex;

    void Awake()
    {
        canAction = true;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
    
    void Talk(int id)
    {
        talkUI.SetActive(true);
        string talkData = talkManager.GetTalk(id, talkIndex);
        talkText.text = talkData;

    }    
}
