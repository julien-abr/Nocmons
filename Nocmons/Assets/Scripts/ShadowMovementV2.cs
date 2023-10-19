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
    
    //Spawn
    private RotationState _spawnRot;
    private int _spawnPoint;
    private int _currentPhase;
    private EventParameter _eventParam;
    private float _currentTimeMove;
    private float _maxTimeMove;
    private bool _canMove = true;
    
    
    public void Init(int currentPhase, EventParameter eventParam, BearReference bearRef, EnemyDetection enemyDetection, RotationState spawnRot, int spawnPoint)
    {
        switch (_spawnPoint)
        {
            case 0:
                distanceState = distance.none;
                break;
            case 1:
                distanceState = distance.twentyFive;
                break;
        }
        
        
        _bearState = bearRef.Instance.GetComponent<BearState>();
        _currentPhase = currentPhase;
        _eventParam = eventParam;
        _timeBeforeDamagingPlayer = _eventParam.shadowTimeBeforeDmg;
        _damagePoint0 = _eventParam.shadowFearPercentPoint0;
        _damagePoint1 = _eventParam.shadowFearPercentPoint1;
        _damagePoint2 = _eventParam.shadowFearPercentPoint2;
        _enemyDetection = enemyDetection;
         _usingLight = _enemyDetection._isUsingLight;
         _spawnRot = spawnRot;
         _spawnPoint = spawnPoint;
         FindMaxTimeMoove();
         isInitialized = true;
    }

    void FindMaxTimeMoove()
    {
        float min = _eventParam.EventPhases[_currentPhase].shadowParam.minTimeBeforeMoving;
        float max = _eventParam.EventPhases[_currentPhase].shadowParam.maxTimeBeforeSpawn;
        _maxTimeMove = Random.Range(min, max);
  
    }
    private Transform MoveToNextPosition()
    {
        SetDistanceState();
        switch (_spawnRot)
        {
            case RotationState.Left:
                return FindTransformInRow(0);
            case RotationState.Middle:
                return FindTransformInRow(1);
            case RotationState.Right:
                return FindTransformInRow(2);
            default:
                return null;
        }
    }

    private Transform FindTransformInRow(int row) //0 : left, 1:middle, 2:right
    {
        switch (_spawnPoint)
        {
            case 1:
                return _eventParam.shadowSpawnSecond[row].gameObject.transform;
            case 2:
                return _eventParam.shadowSpawnThird[row].gameObject.transform;
            case 3:
                return _eventParam.shadowSpawnFourth[row].gameObject.transform;
            case 4 : 
                return transform;
            default:
                return null;
        }
    }

    void SetDistanceState()
    {
        switch (_spawnPoint)
        {
            case 1:
                if (!soundPlayed25)
                {
                    SFXRandom();
                    soundPlayed25 = true;
                }
                distanceState = distance.twentyFive;
                break;
            case 2:
                if (!soundPlayed50)
                {
                    SFXRandom();
                    soundPlayed50 = true;
                }
                distanceState = distance.fifty;
                break;
            case 3:
                if (!soundPlayed75)
                {
                    SFXRandom();
                    soundPlayed75 = true;
                }
                distanceState = distance.seventyFive;
                break;
            case 4:
                if (!soundPlayed100)
                {
                    DeathSFX();
                    soundPlayed100 = true;
                }
                distanceState = distance.isFinish;
                _bearState.ShadowDie(_spawnRot);
                
                break;
        }
    }
    
    void Update()
    {
        if(!isInitialized) {return;}
        
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
        else
        {
            if (!_canMove) { return;}
            
            _currentTimeMove += Time.deltaTime;
            if (_currentTimeMove >= _maxTimeMove)
            {
                _spawnPoint++;
                transform.position = MoveToNextPosition().position;
                if (_spawnPoint != 4)
                {
                    _currentTimeMove = 0;
                    FindMaxTimeMoove();
                }
                else { _canMove = false; }
            }
 
        }
        
    }
    void SFXRandom()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0 :
                AudioManager.instance?.PlayRandom(SoundState.SCRATCH);
                break;
            case 1:
                AudioManager.instance?.PlayRandom(SoundState.CRACKINGFLOOR);
                break;
            case 2:
                AudioManager.instance?.PlayRandom(SoundState.FALLINGOBJECT);
                break;
        }
    }

    void DeathSFX()
    {
        AudioManager.instance?.PlayRandom(SoundState.BREATH);
    }
    public void SetIsSeen(bool result)
    {
        isSeen = result;
        
        if (!isSeen)
        {
            _currentTime = 0;
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
