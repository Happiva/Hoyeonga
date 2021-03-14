using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObstacle : MonoBehaviour
{
    public int objectHP;
    
    void Update()
    {
        if (objectHP == 0) {
            DestroyObject();
        }
    }

    public void Damage(int damage) {
        objectHP -= damage;

        if (objectHP < 0) objectHP = 0;
    }

    void DestroyObject() {
        Debug.Log("Destroyed");

        //파괴 애니메이션 있으면 넣기

        Destroy(this.gameObject);
    }
}
