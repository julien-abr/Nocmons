using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private float minTimeBtwEvent;
    [SerializeField] private float maxTimeBtwEvent;
    [SerializeField] private List<GameObject> listEventsGO = new List<GameObject>();
    [SerializeField] private GameObject eventParent;
    private bool _canSpawn = true;
    public void Init()
    {
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
}

