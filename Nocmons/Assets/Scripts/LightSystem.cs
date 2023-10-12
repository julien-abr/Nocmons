using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Serialization;

public class LightSystem : MonoBehaviour
{
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private BearReference _bearReference;
    
    private int _maxNumberOfBattery;
    private int _currentBattery;
    public int CurrentBattery => _currentBattery;
    private float _timeToRecharge;
    private int _batteryToRecharge;

    [SerializeField] private GameObject _light;
    private bool usingLight;
    private float _lightDuration;
    private bool isRecharging;
    private void Start()
    {
        _bearReference.Instance.GetComponent<BearActions>().EventHandBtn += HandButtonPressed;
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

            StartCoroutine(LightDuration(_lightDuration));
            Recharge();
        }
    }
    void Recharge()
    {
        StartCoroutine(RechargeBattery(_timeToRecharge));
        IEnumerator RechargeBattery(float time)
        {
            yield return new WaitForSeconds(time);
            _currentBattery++;
            _batteryToRecharge--;
            isRecharging = false;
            Recharge();
        }   
    }
    
    
    private IEnumerator LightDuration(float time)
    {
        usingLight = true;
        _light.SetActive(true);
        yield return new WaitForSeconds(time);
        _light.SetActive(false);
        usingLight = false;
    }
}
