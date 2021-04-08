using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectNotice : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private bool playerEnter;
    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerEnter) {
            distance = Vector2.Distance(player.transform.position, transform.position);

            Debug.Log(distance);

            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Debug.Log("Player Enter");
            playerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player Out");
            playerEnter = false;
        }
    }
}
