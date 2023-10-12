using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ShadowMovementV2 : MonoBehaviour
{
     [SerializeField] private Transform _enemyTarget;
     public  float _enemySpeed;
     public float _actualEnemySpeed;

     private void Start()
     {
         _actualEnemySpeed = _enemySpeed;
     }

     void Update()
    {
        if(_enemyTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _enemyTarget.position, _actualEnemySpeed * Time.deltaTime);
        }
        
        
        
        
    }
    
    
}
