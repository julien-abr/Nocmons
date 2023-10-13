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
    [SerializeField] private float timeForFear;
    private bool isCoroutineRunning = false;

    
    
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
                if (!isCoroutineRunning)
                {
                    StartCoroutine(FearDamage());
                }
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


    private IEnumerator FearDamage()
    {
        isCoroutineRunning = true;
        yield  return new WaitForSeconds(timeForFear);

        if (_shadowMovement._actualEnemySpeed == 0)
        {
            Debug.Log("take fear damage");
            
        }
        else
        {
            Debug.Log("it's ok");
        }

        isCoroutineRunning = false;
    }
    
}
