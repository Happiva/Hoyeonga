using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Player가 움직일 수 있는지, 아닌지 관리
    public bool canAction;


    private static GameManager instance;
    public Vector2 lastCheckPoint;

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
}
