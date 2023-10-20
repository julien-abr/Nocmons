using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (_currentBattery == 0)
        {
            AudioManager.instance?.Play("NoMoreBattery");
        }
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
            AudioManager.instance?.Play("PileIsReload");
            if (_currentBattery == 4)
            {
                AudioManager.instance?.Play("PileFullBattery");

            }
        }
    }


    private void ActivateLight()
    {
        
        StartCoroutine(LightDuration(_lightDuration));
        
        IEnumerator LightDuration(float time)
        {
            AudioManager.instance?.Play("LightOn");
            OnLightActivate?.Invoke();
            usingLight = true;
            _light.SetActive(true);
            yield return new WaitForSeconds(time);
            AudioManager.instance?.Play("LightOff");
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
