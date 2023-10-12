using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private float minTimeBtwEvent;
    [SerializeField] private float maxTimeBtwEvent;
    [SerializeField] private List<GameObject> listEventsGO = new List<GameObject>();
    [SerializeField] private GameObject eventParent;
    private bool _canSpawn = true;

    [Header("Event parameters")] 
    [SerializeField] private EventParameter eventParameter;
    private int _currentPhase;
    public void Init()
    {
        if (!eventParameter) { return; }

        WaitUntilNextPhase();
        SpawnRandomEvent();
    }

    private void SpawnRandomEvent()
    {
        int numberOfEvents = listEventsGO.Count;
        if (numberOfEvents == 0) { return;}
        int randomEvent = Random.Range(0, numberOfEvents);

        GameObject Event = Instantiate(listEventsGO[randomEvent], transform.position, Quaternion.identity);
        Event.transform.parent = eventParent.transform;
        
        TransitionToNextEvent();
    }

    private void TransitionToNextEvent()
    {
        if (_canSpawn)
        {
            var randomTime = Random.Range(minTimeBtwEvent, maxTimeBtwEvent);
            StartCoroutine(Transition(randomTime));
        }
        
        IEnumerator Transition(float time)
        {
            yield return new WaitForSeconds(time);
            SpawnRandomEvent();
        }
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
                Win();
            }
        }
    }

    private void Win()
    {
        _canSpawn = false;
    }
}

