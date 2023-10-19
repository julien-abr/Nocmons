using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BatteryLeftIndicator : MonoBehaviour
{
    [SerializeField] private LightSystem _lightSystem;
    [SerializeField] private TextMeshProUGUI _batteryCounter;


    private void Update()
    {
        _batteryCounter.text = _lightSystem.CurrentBattery.ToString();
    }
}
