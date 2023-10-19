using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public static ShadowManager instance;
    public List<GameObject> shadowSpawn;

    public List<GameObject> shadowSpawn1;
    public List<GameObject> shadowSpawn2;
    public List<GameObject> shadowSpawn3;

    public GameObject FirstShadow;

   
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
