using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

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
    private EnemyDetection _enemyDetection;
    private bool _usingLight;

    private bool soundPlayed25;
    private bool soundPlayed50;
    private bool soundPlayed75;
    private bool soundPlayed100;
    
    
    public void Init(float maxSpeed, float timeBeforeDamaging, float dmg0, float dmg1, float dmg2, BearReference bearRef, EnemyDetection enemyDetection)
    {
        distanceState = distance.none;
        _startPosition = transform.position;
        
        _bearState = bearRef.Instance.GetComponent<BearState>();
        _bearTransform = bearRef.Instance.GetComponent<Transform>();
        _totalDistance = Vector3.Distance(_startPosition, _bearTransform.position);
            
        _maxSpeed = maxSpeed;
        _speed = _maxSpeed;
        _timeBeforeDamagingPlayer = timeBeforeDamaging;
        _damagePoint0 = dmg0;
        _damagePoint1 = dmg1;
        _damagePoint2 = dmg2;
        _enemyDetection = enemyDetection;
         _usingLight = _enemyDetection._isUsingLight;
        
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
                if (!soundPlayed25)
                {
                    SFXRandom();
                    soundPlayed25 = true;
                }
            }
            if (percentageCovered >= 50)
            {
                distanceState = distance.fifty;
                if (!soundPlayed50)
                {
                    SFXRandom();
                    soundPlayed50 = true;
                }
                    
                
            }
            if (percentageCovered >= 75)
            {
                distanceState = distance.seventyFive;
                if (!soundPlayed75)
                {
                    SFXRandom();
                    soundPlayed75 = true;
                }
            }
            if (percentageCovered >= 100)
            {
                distanceState = distance.isFinish;
                if (!soundPlayed100)
                {
                    DeathSFX();
                    soundPlayed100 = true;
                }
                _bearState.Die();
            }
        }

        if (isSeen)
        {
            if (_usingLight)
            {
                //Death coroutine
                _enemyDetection.RemoveObject(gameObject);
                Destroy((transform.parent.gameObject));
            }
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

    void SFXRandom()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0 :
                AudioManager.instance.PlayRandom(SoundState.SCRATCH);
                break;
            case 1:
                AudioManager.instance.PlayRandom(SoundState.CRACKINGFLOOR);
                break;
            case 2:
                AudioManager.instance.PlayRandom(SoundState.FALLINGOBJECT);
                break;
        }
    }

    void DeathSFX()
    {
        AudioManager.instance.PlayRandom(SoundState.BREATH);
    }
    public void SetIsSeen(bool result)
    {
        isSeen = result;
        
        if (!isSeen)
        {
            _currentTime = 0;
            _speed = _maxSpeed;
        }
        else
        {
            _speed = 0;
        }
    }

    public void SetUsingLight(bool result)
    {
        _usingLight = result;
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
