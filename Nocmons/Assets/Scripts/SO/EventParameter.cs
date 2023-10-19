using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EventParam")]
public class EventParameter : ScriptableObject
{
    public EventPhase[] EventPhases = new EventPhase[3];

    [Header("ShadowGlobalParam")]
    public List<GameObject> shadowSpawnFirst;
    public List<GameObject> shadowSpawnSecond;
    public List<GameObject> shadowSpawnThird;
    public List<GameObject> shadowSpawnFourth;
    public float shadowTimeBeforeDmg;
    public float shadowFearPercentPoint0;
    public float shadowFearPercentPoint1;
    public float shadowFearPercentPoint2;

    [Header("LighteningGlobalParam")]
    public float lighteningTimeBeforeDmg;
    public float lighteningFearPercent;

    [Header("LightGlobalParam")] 
    public float lightOnTime;
    public int lightNumberOfBattery;
    public float lightTimeBeforeRecharging;

    [Header("CuddlingGlobalParam")]
    public float cuddlingFearPercent;
    
    [Header("BearSpeakingGlobalParam")]
    public float bearSpeakingFearPercent;
    public int bearSpeakingNumberOfBatteryNeeded;

    [Header("CameraGlobalParam")] 
    public float cameraRotateSpeed;
    public Vector3 cameraLeft;
    public Vector3 cameraMiddle;
    public Vector3 cameraRight;
}

[System.Serializable]
public class EventPhase
{
    public int PhaseDuration;
    public ShadowParam shadowParam;
    public LighteningParam lighteningParam;
}

[System.Serializable]
public class ShadowParam
{
    public float minTimeBeforeSpawn;
    public float maxTimeBeforeSpawn;
    public float fearPercent;
    public List<int> shadowSpawnPoint = new List<int>();
    public float minTimeBeforeMoving;
    public float maxTimeBeforeMoving;
}

[System.Serializable]
public class LighteningParam
{
    public float minTimeBeforeSpawn;
    public float maxTimeBeforeSpawn;
}
