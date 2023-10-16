using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShadowMovementV2 : MonoBehaviour
{
    [SerializeField] private Transform _enemyTarget;
    public int _enemySpeed;
    public int _actualEnemySpeed;
    private Vector3 _startPosition;
    private float _totalDistance;

    public distance distanceState;

    private void Start()
    {
        distanceState = distance.none;
        _actualEnemySpeed = _enemySpeed;
        _startPosition = transform.position;
        _totalDistance = Vector3.Distance(_startPosition, _enemyTarget.position);
    }
    

    void Update()
    {
        if (_enemyTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _enemyTarget.position, _actualEnemySpeed * Time.deltaTime);
        
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
            }
        }
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
