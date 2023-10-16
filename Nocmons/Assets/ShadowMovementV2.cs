using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ShadowMovementV2 : MonoBehaviour
{
    private BearState _bearState;
    private Transform _bearTransform;
    private float _speed;
    private float _maxSpeed;
    
    //Damage
    private float _currentTime;
    private float _timeBeforeDamagingPlayer;
    private float _damagePoint0;
    private float _damagePoint1;
    private float _damagePoint2;
    
    private Vector3 _startPosition;
    private float _totalDistance;
    public distance distanceState;

    private bool isInitialized;
    private bool isSeen;
    
    public void Init(float maxSpeed, float timeBeforeDamaging, float dmg0, float dmg1, float dmg2, BearReference bearRef)
    {
        distanceState = distance.none;
        _startPosition = transform.position;
        _totalDistance = Vector3.Distance(_startPosition, _bearTransform.position);
            
        _maxSpeed = maxSpeed;
        _speed = _maxSpeed;
        _timeBeforeDamagingPlayer = timeBeforeDamaging;
        _damagePoint0 = dmg0;
        _damagePoint1 = dmg1;
        _damagePoint2 = dmg2;

        _bearState = bearRef.Instance.GetComponent<BearState>();
        _bearTransform = bearRef.Instance.GetComponent<Transform>();
            
        isInitialized = true;
    }
    

    void Update()
    {
        if (_bearTransform != null && isInitialized)
        {
            var speed = (_speed * Time.deltaTime) / 4;
            transform.position = Vector3.MoveTowards(transform.position, _bearTransform.position, speed);
        
            float distanceCovered = Vector3.Distance(_startPosition, transform.position);

            float percentageCovered = (distanceCovered / _totalDistance) * 100;

            if (percentageCovered >= 25)
            {
                distanceState = distance.twentyFive;
            }
            if (percentageCovered >= 50)
            {
                distanceState = distance.fifty;
            }
            if (percentageCovered >= 75)
            {
                distanceState = distance.seventyFive;
            }
            if (percentageCovered >= 100)
            {
                distanceState = distance.isFinish;
                _bearState.Die();
            }
        }

        if (isSeen)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _timeBeforeDamagingPlayer)
            {
                switch (distanceState)
                {
                    case distance.none :
                        _bearState.TakeFear(_damagePoint0);
                        break;
                    case distance.twentyFive : 
                        _bearState.TakeFear(_damagePoint0);
                        break;
                    case distance.fifty :
                        _bearState.TakeFear(_damagePoint1);
                        break;
                    case distance.seventyFive : 
                        _bearState.TakeFear(_damagePoint2);
                        break;
                }

                _currentTime = 0;
            }
        }
    }

    public void SetIsSeen(bool result)
    {
        isSeen = result;

        _speed = !isSeen ? 0 : _maxSpeed;
    }

    public enum distance
    {
        none,
        twentyFive,
        fifty,
        seventyFive,
        isFinish,
    };


}
