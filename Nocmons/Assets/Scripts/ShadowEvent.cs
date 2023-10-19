using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowEvent : Event
{
    [SerializeField] private BearReference bearRef;
    [SerializeField] private EventParameter eventParameter;
     
    [SerializeField] private GameObject objectToSpawn;
    private EnemyDetection _enemyDetection;
    private RotationState _spawnRot;
    private int randomSpawn;
    private int _currentPhase;
    
    private Transform actualSpawnPoint;

    private bool firstLigneSpawn = false;
    private bool secondLineSpawn = false;
    public void Init(int currentPhase)
    {
        _currentPhase = currentPhase;
        var spawnPointList = eventParameter.EventPhases[_currentPhase].shadowParam.shadowSpawnPoint;
        randomSpawn = Random.Range(0, spawnPointList.Count);
        switch (randomSpawn)
        {
            case 0:
                int i = Random.Range(0, eventParameter.shadowSpawnFirst.Count);
                firstLigneSpawn = true;
                FindSpawnRot(i);
                actualSpawnPoint = eventParameter.shadowSpawnFirst[i].transform;
                break;
            case 1:
                int j = Random.Range(0, eventParameter.shadowSpawnSecond.Count);
                secondLineSpawn = true;
                FindSpawnRot(j);
                actualSpawnPoint = eventParameter.shadowSpawnSecond[j].transform;
                break;
        }
        float minSpeed = eventParameter.EventPhases[_currentPhase].shadowParam.minTimeBeforeMoving;
        float maxSpeed = eventParameter.EventPhases[_currentPhase].shadowParam.maxTimeBeforeSpawn;
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        
        StartEvent(randomSpawn, randomSpeed);
    }
    void StartEvent(int spawnPoint, float randomSpeed)
    {
        _enemyDetection = bearRef.Instance.GetComponent<EnemyDetection>();
        GameObject go = Instantiate(objectToSpawn, actualSpawnPoint.position, actualSpawnPoint.rotation);
        go.transform.parent = this.transform;
        float timeBeforeDmg = eventParameter.shadowTimeBeforeDmg;
        float dmg0 = eventParameter.shadowFearPercentPoint0;
        float dmg1 = eventParameter.shadowFearPercentPoint1;
        float dmg2 = eventParameter.shadowFearPercentPoint2;
        go.GetComponent<ShadowMovementV2>().Init(_currentPhase, eventParameter, bearRef, _enemyDetection, _spawnRot, spawnPoint);
        _enemyDetection.AddObject(go);
        //add sound
    }

    private void FindSpawnRot(int spawnInt)
    {
        switch (spawnInt)
        {
            case 0:
                _spawnRot = RotationState.Left;
                ShadowManager.instance.shadowSpawn[spawnInt].SetActive(true);
                ShadowManager.instance.FirstShadow = ShadowManager.instance.shadowSpawn[spawnInt];
                break;
            case 1:
                ShadowManager.instance.shadowSpawn[spawnInt].SetActive(true);
                ShadowManager.instance.FirstShadow = ShadowManager.instance.shadowSpawn[spawnInt];
                _spawnRot = RotationState.Middle;
                break;
            case 2:
                ShadowManager.instance.shadowSpawn[spawnInt].SetActive(true);
                ShadowManager.instance.FirstShadow = ShadowManager.instance.shadowSpawn[spawnInt];
                _spawnRot = RotationState.Right;
                break;
            default:
                Debug.Log("Trop de spawn point shadow");
                break;
        }
    }

}
