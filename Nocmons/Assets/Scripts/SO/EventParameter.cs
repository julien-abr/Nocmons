using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/EventParam")]
public class EventParameter : ScriptableObject
{
    public EventPhase[] EventPhases = new EventPhase[3];
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
