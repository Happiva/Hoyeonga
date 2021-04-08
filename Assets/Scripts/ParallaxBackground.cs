using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 parallexEffectMultiplier;

    public GameObject mainCamera;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    void Start()
    {
        cameraTransform = mainCamera.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        
        transform.position += new Vector3(deltaMovement.x * parallexEffectMultiplier.x, deltaMovement.y * parallexEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
    }
}
