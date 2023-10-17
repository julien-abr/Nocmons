using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSystem : MonoBehaviour
{
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private BearReference bearReference;
    
    private int _maxNumberOfBattery;
    private int _currentBattery;
    public int CurrentBattery => _currentBattery;
    private float _timeToRecharge;

    [SerializeField] private GameObject _light;
    private bool usingLight;
    private float _lightDuration;
    
    public event Action OnLightActivate;
     public event Action OnLightDeactivate;
    

    private void Start()
    {
        bearReference.Instance.GetComponent<BearActions>().EventHandBtn += HandButtonPressed;
        _maxNumberOfBattery = eventParameter.lightNumberOfBattery;
        _timeToRecharge = eventParameter.lightTimeBeforeRecharging;
        _lightDuration = eventParameter.lightOnTime;
        _currentBattery = _maxNumberOfBattery;
    }
    void HandButtonPressed()
    {
        UseLight();
    }

    void UseLight()
    {
        if (_currentBattery > 0 && !usingLight)
        {
            _currentBattery--;

            ActivateLight();
            Recharge(1);
        }
    }
    public void Recharge(int amount)
    {
        StartCoroutine(RechargeBattery(_timeToRecharge));
        IEnumerator RechargeBattery(float time)
        {
            yield return new WaitForSeconds(time * amount);
            _currentBattery += amount;
        }   
    }


    private void ActivateLight()
    {
        
        StartCoroutine(LightDuration(_lightDuration));
        
        IEnumerator LightDuration(float time)
        {
            OnLightActivate?.Invoke();
            usingLight = true;
            _light.SetActive(true);
            yield return new WaitForSeconds(time);
            _light.SetActive(false);
            usingLight = false;
            OnLightDeactivate?.Invoke();
        }
    }

    public void RemoveBattery(int amount)
    {
        _currentBattery = Mathf.Clamp(_currentBattery -= amount, 0, _maxNumberOfBattery);
    }
}
