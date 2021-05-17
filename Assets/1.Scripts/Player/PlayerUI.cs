using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Player player;
    private Image image;

    public Sprite hp1, hp2, hp3;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        image = GetComponent<Image>();
    }
    
    void Update()
    {
        switch (player.playerHP)
        {
            case 1:
                image.sprite = hp1;
                break;
            case 2:
                image.sprite = hp2;
                break;
            case 3:
                image.sprite = hp3;
                break;                
        }
    }
}
