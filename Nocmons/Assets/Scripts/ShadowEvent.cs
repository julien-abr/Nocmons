using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowEvent : Event
{
    [SerializeField] private BearReference bearRef;
    [SerializeField] private Transform[] spawnPoints; 
    [SerializeField] private GameObject objectToSpawn; 
    [SerializeField] private float minSpawnTime = 2.0f; 
    [SerializeField] private float maxSpawnTime = 5.0f; 
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    
    private IEnumerator SpawnObject()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnIndex];
        
        
        
        GameObject go = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        bearRef.Instance.GetComponent<EnemyDetection>().AddShadow(go);
        //ajouter un bruit pour savoir qu'une ombre a été instancié
        
        
        
        float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(randomSpawnTime);

    }
    
}
