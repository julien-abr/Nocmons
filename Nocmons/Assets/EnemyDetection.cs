using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private ShadowMovementV2 _shadowMovement;
    [SerializeField] private Camera camera; 
    
    private GameObject objectToDetect; 
    [SerializeField] private float timeForFear;
    private bool isCoroutineRunning = false;


    [SerializeField] private BearReference bearRef;
    private BearState _bearState;
    [SerializeField] private EventParameter _eventParameter;
    public void AddShadow(GameObject shadow)
    {
        Debug.Log(shadow.name);
        objectToDetect = shadow;
        _shadowMovement = objectToDetect.GetComponent<ShadowMovementV2>();
    }

    private void Start()
    {
        _bearState = bearRef.Instance.GetComponent<BearState>();
    }

    private void Update()
    {
        if (objectToDetect == null || camera == null)
        {
            return;
        }

        if (_shadowMovement.distanceState == ShadowMovementV2.distance.isFinish)
        {
            Debug.Log("100");
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
            switch (_shadowMovement.distanceState)
            {
                case ShadowMovementV2.distance.none :
                    _bearState.TakeFear(_eventParameter.shadowFearPercentPoint0);
                    break;
                case ShadowMovementV2.distance.twentyFive : 
                    _bearState.TakeFear(_eventParameter.shadowFearPercentPoint0);
                    break;
                case ShadowMovementV2.distance.fifty :
                    _bearState.TakeFear(_eventParameter.shadowFearPercentPoint1);
                    break;
                case ShadowMovementV2.distance.seventyFive : 
                    _bearState.TakeFear(_eventParameter.shadowFearPercentPoint2);
                    break;
            }
            
        }
        else
        {
            Debug.Log("it's ok");
        }

        isCoroutineRunning = false;
    }
    
}
