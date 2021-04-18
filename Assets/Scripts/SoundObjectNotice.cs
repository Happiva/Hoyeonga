using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectNotice : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private bool playerEnter;
    private float distance;
    private float angle;

    private Renderer renderer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (playerEnter) {
            distance = Vector2.Distance(player.transform.position, transform.position);
            angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

            //Debug.Log(distance);
            //Debug.Log(angle);
            Debug.Log(renderer.isVisible);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            playerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerEnter = false;
        }
    }
}
