using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int playerHP;

    public int fullHP = 3;

    public bool playerDead;

    public SpriteRenderer spriteRenderer;
    private GameManager gameManager;

    void Start()
    {
        playerHP = 1;
        playerDead = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        gameManager.lastCheckPoint = transform.position;
    }

    
    void Update()
    {
        if (playerHP <= 0) playerDead = true;


        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0) {
            spriteRenderer.flipX = false;
        }

        if (playerDead)
        {
            Debug.Log("Game Over!");
            //Destroy(this.gameObject);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Damage(int damage)
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
