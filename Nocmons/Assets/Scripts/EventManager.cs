using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject lightningEvent;
    [SerializeField] private GameObject ShadowEvent;
    [SerializeField] private GameObject eventParent;
    [SerializeField] private int timeBeforeStartingAllEvents;
    private bool _canSpawn = true;

    [Header("Event parameters")] 
    [SerializeField] private EventParameter eventParameter;
    
    [Header("Bear Ref")] 
    [SerializeField] private BearReference bearReference;
    private BearState bearState;
    
    private int _currentPhase;
    public void Init()
    {
        if (!eventParameter) { return; }

        bearState = bearReference.Instance.GetComponent<BearState>();
        bearState.OnWin += StopSpawn;
        bearState.OnDied += StopSpawn;
        WaitUntilNextPhase();
        SpawnEvent();
    }

    private void SpawnEvent()
    {
        if (lightningEvent == null || ShadowEvent == null) { return;}

        SpawnEvent(EventType.Shadow);
    }

    private IEnumerator StartShadowEvent()
    {
        if (!_canSpawn) { yield break; }
        
        float minTime = eventParameter.EventPhases[_currentPhase].shadowParam.minTimeBeforeSpawn;
        float maxTime = eventParameter.EventPhases[_currentPhase].shadowParam.maxTimeBeforeSpawn;
        float random = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(random);
        SpawnEvent(EventType.Shadow);
        StartShadowEvent();
    }

    private IEnumerator StartLightingEvent()
    {
        if (!_canSpawn) { yield break; }
        
        float minTime = eventParameter.EventPhases[_currentPhase].lighteningParam.minTimeBeforeSpawn;
        float maxTime = eventParameter.EventPhases[_currentPhase].lighteningParam.maxTimeBeforeSpawn;
        float random = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(random);
        SpawnEvent(EventType.Lightning);
        StartShadowEvent();
    }

    private void WaitUntilNextPhase()
    {
        StartCoroutine(Transition(eventParameter.EventPhases[_currentPhase].PhaseDuration));
        
        IEnumerator Transition(float time)
        {
            yield return new WaitForSeconds(time);

            if (_currentPhase + 1 < eventParameter.EventPhases.Length)
            {
                _currentPhase++;
                WaitUntilNextPhase();
            }
            else if (_currentPhase + 1 == eventParameter.EventPhases.Length)
            {
                bearState.Win();
            }
        }
    }

    private void StopSpawn()
    {
        _canSpawn = false;
    }

    private IEnumerator SpawnEvent(EventType eventType)
    {
        switch (eventType)
        {
            case EventType.Lightning:
                GameObject EventLightning = Instantiate(lightningEvent, transform.position, Quaternion.identity);
                EventLightning.transform.parent = eventParent.transform;
                break;
            case EventType.Shadow:
                GameObject EventShadow = Instantiate(ShadowEvent, transform.position, Quaternion.identity);
                EventShadow.transform.parent = eventParent.transform;
                EventShadow.GetComponent<ShadowEvent>().Init(_currentPhase);
                break;
        }
        
        yield return new WaitForSeconds(timeBeforeStartingAllEvents);
        StartShadowEvent();
        StartLightingEvent();
    }
}

enum EventType
{
    Lightning,
    Shadow,
}

