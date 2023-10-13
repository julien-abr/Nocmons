using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private ShadowMovementV2 _shadowMovement;
    [SerializeField] private Camera camera; 
    [SerializeField] private GameObject objectToDetect; 
    [SerializeField] private float detectionDistance = 10f; 

    
    private void Start()
    {
        _shadowMovement = FindObjectOfType<ShadowMovementV2>();
    }
    private void Update()
    {
        if (objectToDetect == null || camera == null)
        {
            return;
        }

        Vector3 screenPoint = camera.WorldToScreenPoint(objectToDetect.transform.position);

        if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < Screen.width && screenPoint.y > 0 && screenPoint.y < Screen.height)
        {
            if (_shadowMovement != null)
            {
                _shadowMovement._actualEnemySpeed = 0;
            }
        }
        else
        {
            if (_shadowMovement != null)
            {
                _shadowMovement._actualEnemySpeed = _shadowMovement._enemySpeed;
            }
        }
    }
    
}
