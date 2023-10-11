using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearState : MonoBehaviour
{
    private float maxFearValue = 100;
    [SerializeField] private float currentFearValue;
    public float CurrentFearValue => currentFearValue;
    public float MaxFearValue => maxFearValue;
    public bool IsDead => currentFearValue >= maxFearValue;

    private bool _isCuddling = false;
    private float _currentTime;

    [Header("Param"), Tooltip("how many fear percent we loose by seconds when cuddling")] 
    [SerializeField] private float cuddlingPercentValue;
    
    //[Header("LightVariables")]
    

    void Start()
    {
        BearActions actions = GetComponent<BearActions>();
        actions.EventChestBtn += StartCuddling;
        actions.EventCanceledChestBtn += StopCuddling;
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
                    RemoveFear(cuddlingPercentValue);
                    _currentTime = 0;
                }
            }
        }
    }

    public void TakeFear(float amount)
    {
        if (!IsDead)
        {
            currentFearValue = Mathf.Clamp(currentFearValue + amount, 0f, maxFearValue);
        }

        if (IsDead)
        {
            Die();
        }
    }
    
    public void RemoveFear(float amount)
    {
        if (!IsDead)
        {
            currentFearValue = Mathf.Clamp(currentFearValue - amount, 0f, maxFearValue);
        }
    }
    
    //public void 

    private void Die()
    {
        
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
    
}
