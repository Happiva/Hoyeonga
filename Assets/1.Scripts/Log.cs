using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Animator ani;
    private Rigidbody2D rigid;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ani.SetFloat("Speed", rigid.velocity.x);
    }
}
