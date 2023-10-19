using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private EventParameter EventParameter;

    
    
    
    private float _remainingTime;
    private bool _isInitialized;

    private void Start()
    {
        foreach (var phase in EventParameter.EventPhases)
        {
            _remainingTime += phase.PhaseDuration;
        }

        _isInitialized = true;

       
    }

    private void Update()
    {
        if(!_isInitialized) {return;}
        
        if (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }
        else if (_remainingTime < 0)
        {
            _remainingTime = 0;
        }
        int minutes = Mathf.FloorToInt(_remainingTime / 60);
        int seconds = Mathf.FloorToInt(_remainingTime % 60);
        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
    }
}
