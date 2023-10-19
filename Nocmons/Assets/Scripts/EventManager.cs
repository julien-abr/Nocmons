using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    private bool alreadyDone = false;
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
        StartCoroutine(SpawnEvent(EventType.Shadow));
    }

    private IEnumerator StartShadowEvent()
    {
        if (!_canSpawn) { yield break; }
        
        float minTime = eventParameter.EventPhases[_currentPhase].shadowParam.minTimeBeforeSpawn;
        float maxTime = eventParameter.EventPhases[_currentPhase].shadowParam.maxTimeBeforeSpawn;
        float random = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(random);
        StartCoroutine(SpawnEvent(EventType.Shadow));
        StartCoroutine(StartShadowEvent());
    }

    private IEnumerator StartLightingEvent()
    {
        if (!_canSpawn) { yield break; }
        
        float minTime = eventParameter.EventPhases[_currentPhase].lighteningParam.minTimeBeforeSpawn;
        float maxTime = eventParameter.EventPhases[_currentPhase].lighteningParam.maxTimeBeforeSpawn;
        float random = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(random);
        StartCoroutine(SpawnEvent(EventType.Lightning));
        StartCoroutine(StartLightingEvent());
        
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
                AudioManager.instance?.Play("LightningNear");
                EventLightning.transform.parent = eventParent.transform;
                EventLightning.GetComponent<LightningEvent>().Init();
                break;
            case EventType.Shadow:
                GameObject EventShadow = Instantiate(ShadowEvent, eventParameter.tunderSpawn[tunderSpawn()].transform.position, Quaternion.identity);
                AudioManager.instance?.Play("ShadowSpawn");
                EventShadow.transform.parent = eventParent.transform;
                EventShadow.GetComponent<ShadowEvent>().Init(_currentPhase);
                break;
        }

        if (!alreadyDone)
        {
            yield return new WaitForSeconds(timeBeforeStartingAllEvents);
            StartCoroutine(StartShadowEvent());
            StartCoroutine(StartLightingEvent());
            alreadyDone = true;
        }
        
    }

    private int tunderSpawn()
    {
        if (bearState.CurrentRot == RotationState.Left)
        {
            return 0;
        }
        if (bearState.CurrentRot == RotationState.Middle)
        {
            return 1;
        }
        if (bearState.CurrentRot == RotationState.Right)
        {
            return 2;
        }

        return 0;
    }
    
    
}

enum EventType
{
    Lightning,
    Shadow,
}

