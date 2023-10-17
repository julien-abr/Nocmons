using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowEvent : Event
{
    [SerializeField] private BearReference bearRef;
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private GameObject objectToSpawn;
    private EnemyDetection _enemyDetection;
    public void Init(int currentPhase)
    {
        var spawnPointList = eventParameter.EventPhases[currentPhase].shadowParam.shadowSpawnPoint;
        int randomSpawn = Random.Range(0, spawnPointList.Count);
        float minSpeed = eventParameter.EventPhases[currentPhase].shadowParam.minTimeBeforeMoving;
        float maxSpeed = eventParameter.EventPhases[currentPhase].shadowParam.maxTimeBeforeSpawn;
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        
        StartEvent(randomSpawn, randomSpeed);
    }
    void StartEvent(int spawnPoint, float randomSpeed)
    {
        Transform spawnTransform = spawnPoints[spawnPoint];
        _enemyDetection = bearRef.Instance.GetComponent<EnemyDetection>();
        GameObject go = Instantiate(objectToSpawn, spawnTransform.position, spawnTransform.rotation);
        go.transform.parent = this.transform;
        float timeBeforeDmg = eventParameter.shadowTimeBeforeDmg;
        float dmg0 = eventParameter.shadowFearPercentPoint0;
        float dmg1 = eventParameter.shadowFearPercentPoint1;
        float dmg2 = eventParameter.shadowFearPercentPoint2;
        go.GetComponent<ShadowMovementV2>().Init(randomSpeed,timeBeforeDmg, dmg0, dmg1, dmg2, bearRef, _enemyDetection);
        _enemyDetection.AddObject(go);
        //add sound
        AudioManager.instance.Play("ShadowSpawn");
    }

}
