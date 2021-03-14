using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int playerHP;

    public int fullHP = 3;

    public bool playerDead;

    void Start()
    {
        playerHP = 1;
        playerDead = false;
    }

    
    void Update()
    {
        if (playerHP <= 0) playerDead = true;
    }

    void Damage(int damage)
    {
        playerHP -= damage;

        if (playerHP < 0) playerHP = 0;

        ChangeLookByHP();
    }

    void Heal(int healAmount)
    {
        playerHP += healAmount;

        if (playerHP > 3) playerHP = 3;

        ChangeLookByHP();
    }


    //Player 체력에 따라 Player의 외관이 바뀜.
    void ChangeLookByHP()
    {
        if (playerHP == 1)
        {

        }
        else if (playerHP == 2)
        {

        }
        else if (playerHP == 3)
        {

        }

        return;
    }
}
