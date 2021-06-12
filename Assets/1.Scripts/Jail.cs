using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator ani;
    public GameObject dust;
    public GameObject empty_jail;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ani.SetBool("Drop", true);            
        }

        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log(transform.position);
            dust.transform.parent = GameObject.Find("Object").transform;
            dust.GetComponent<Animator>().SetTrigger("Play");
            //ani.SetBool("Broke", true);
            GameObject ins = Instantiate(empty_jail, transform.position, Quaternion.identity);
            ins.transform.parent = GameObject.Find("Object").transform;

            //Invoke("DestroyObject", 1f);
            Destroy(gameObject);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }


    void Drop()
    {
        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
