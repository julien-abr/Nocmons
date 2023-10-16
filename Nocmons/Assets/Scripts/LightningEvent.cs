using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class LightningEvent : MonoBehaviour
{
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private BearReference bearReference;
    private ThunderRender _thunderRender;
    private float _thunderDuration;
    private float _takeFearPercent;
    private bool _isBearHidingLeftEye;
    private bool _isBearHidingRightEye;

    private BearState bearState;

    public void Init(int currentPhase)
    {
        bearState = bearReference.Instance.GetComponent<BearState>();
        _thunderRender = gameObject.GetComponent<ThunderRender>();
        bearReference.Instance.GetComponent<BearActions>().EventShowLeftEye += () => _isBearHidingLeftEye = false;
        bearReference.Instance.GetComponent<BearActions>().EventHideLeftEye += () => _isBearHidingLeftEye = true;
        bearReference.Instance.GetComponent<BearActions>().EventShowRightEye += () => _isBearHidingRightEye = false;
        bearReference.Instance.GetComponent<BearActions>().EventHideRightEye += () => _isBearHidingRightEye = true;
        _thunderDuration = eventParameter.lighteningTimeBeforeDmg;
        _takeFearPercent = eventParameter.lighteningFearPercent;
         
        StartEvent();
    }
    
    void StartEvent()
    {
        StartCoroutine(LaunchThunder());
        
        IEnumerator LaunchThunder()
        {
            _thunderRender.LightningEffect();

            yield return new WaitForSeconds(_thunderDuration);

            if (!_isBearHidingLeftEye && !_isBearHidingRightEye)
            {
                bearState.TakeFear(_takeFearPercent);
            }
        }
    }

    public void EffectEnded()
    {
        Destroy(this.gameObject);
    }
    
}
