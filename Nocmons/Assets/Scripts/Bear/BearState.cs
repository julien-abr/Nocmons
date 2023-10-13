using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BearState : MonoBehaviour
{
    //Inspector var
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private LightSystem lightsystem;
    
    //Fear value
    private const float _maxFearValue = 100;
    [SerializeField] private float currentFearValue;
    public float CurrentFearValue => currentFearValue;
    public float MaxFearValue => _maxFearValue;
    public bool IsDead => currentFearValue >= _maxFearValue;

    //Cuddling
    private bool _isCuddling = false;
    private float _currentTime;
    private float _cuddlingPercentValue;
    
    //Bear Speaking
    private float _bearSpeakingPercentValue;
    private int _bearSpeakingBatteryNeeded;
    
    //Events
    public event Action OnDied;
    public event Action OnWin;

    void Start()
    {
        _cuddlingPercentValue = eventParameter.cuddlingFearPercent;
        _bearSpeakingPercentValue = eventParameter.bearSpeakingFearPercent;
        _bearSpeakingBatteryNeeded = eventParameter.bearSpeakingNumberOfBatteryNeeded;
        BearActions actions = GetComponent<BearActions>();
        actions.EventChestBtn += StartCuddling;
        actions.EventCanceledChestBtn += StopCuddling;
        actions.EventHeadBtn += BearSpeaking;
    }

    private void Update()
    {
        if (!IsDead)
        {
            if (_isCuddling)
            {
                _currentTime += Time.deltaTime;

                if (_currentTime >= 1f)
                {
                    RemoveFear(_cuddlingPercentValue);
                    _currentTime = 0;
                }
            }
        }
    }

    public void TakeFear(float amount)
    {
        if (IsDead)
        {
            Die();
            return;
        }
        currentFearValue = Mathf.Clamp(currentFearValue + amount, 0f, _maxFearValue);

        if (IsDead)
        {
            Die();
        }
    }
    
    public void RemoveFear(float amount)
    {
        if (IsDead)
        {
            Die();
            return;
        }
        
        currentFearValue = Mathf.Clamp(currentFearValue - amount, 0f, _maxFearValue);
    }
    
    //public void 

    public void Die()
    {
        Debug.Log("Loose");
        OnDied?.Invoke();
    }

    public void Win()
    {
        Debug.Log("Win");
        OnWin?.Invoke();
    }
    private void StartCuddling()
    {
        _isCuddling = true;
    }
    
    private void StopCuddling()
    {
        _isCuddling = false;
        _currentTime = 0;
    }

    private void BearSpeaking()
    {
        if (lightsystem.CurrentBattery >= _bearSpeakingBatteryNeeded)
        {
            //Sound bear speaking
            RemoveFear(_bearSpeakingPercentValue);
            lightsystem.RemoveBattery(_bearSpeakingBatteryNeeded);
            lightsystem.Recharge(_bearSpeakingBatteryNeeded);
        }
    }
    
}
