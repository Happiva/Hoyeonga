using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //임시 코드 (좀 더 조사해보고 수정)

    public GameObject target;

    private float viewOffset; //방향키로 시점 이동 시 카메라를 이동할 거리

    private float viewMove;

    private bool cameraMove;

    void Start()
    {
        viewOffset = 4f;
        cameraMove = false;
    }

    
    void LateUpdate()
    {
        //Camera가 Player를 위주로 움직임. (임시)
        Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, -10);        

        //방향키를 이용한 Camera의 이동.
        viewMove = Input.GetAxisRaw("Vertical");


        if (Input.GetButton("Vertical"))
        {
            Vector3 pos;

            cameraMove = true;

            if (viewMove > 0)
            {
                pos = new Vector3(target.transform.position.x, target.transform.position.y + viewOffset, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);

            }
            else if (viewMove < 0)
            {
                pos = new Vector3(target.transform.position.x, target.transform.position.y - viewOffset, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 2f);
            }

        } else if (!cameraMove){
            transform.position = targetPosition;
        }

        if (Input.GetButtonUp("Vertical"))
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 2f);

            cameraMove = false;
        }
    }
}
