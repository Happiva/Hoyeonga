using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public enum Trap_Type { HOLE, SPIKE }
    public Trap_Type trapType;

    public int damageAmount;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered");

            switch (trapType)
            {
                case Trap_Type.HOLE:
                    col.gameObject.GetComponent<Player>().Damage(damageAmount);
                    break;

                case Trap_Type.SPIKE:
                    GetComponent<Animator>().SetTrigger("isCaught");
                    //col.gameObject.GetComponent<PlayerController>().ControlPlayerAction(false);
                    break;
            }            
        }
    }
}
