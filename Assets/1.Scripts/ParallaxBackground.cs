using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{   
    public GameObject mainCamera;

    /*
    [SerializeField] private Vector2 parallexEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    */

    private float lengthX, lengthY;
    private Vector3 startPos;
    public Vector2 parallexEffectMultiplier;

    void Start()
    {
        /*
        cameraTransform = mainCamera.transform;
        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit);

        Debug.Log(this.name + " / textureUnitSize : " + textureUnitSizeX);
        */

        startPos = transform.position;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void LateUpdate()
    {
        /*
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

        transform.position += new Vector3(deltaMovement.x * parallexEffectMultiplier.x, deltaMovement.y * parallexEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;        

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
        */

        float tempX = (mainCamera.transform.position.x * (1 - parallexEffectMultiplier.x));
        float tempY = (mainCamera.transform.position.y * (1 - parallexEffectMultiplier.y));

        float distX = (mainCamera.transform.position.x * parallexEffectMultiplier.x);
        float distY = (mainCamera.transform.position.y * parallexEffectMultiplier.y);

        transform.position = new Vector3(startPos.x + distX, startPos.y + distY, transform.position.z);

        if (tempX > startPos.x + lengthX) startPos.x += lengthX;
        else if (tempX < startPos.x - lengthX) startPos.x -= lengthX;

        if (tempY > startPos.y + lengthY) startPos.y += lengthY;
        else if (tempY < startPos.y - lengthY) startPos.y -= lengthY;
    }
}
