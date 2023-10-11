using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BearActions : MonoBehaviour, IBearActions
{
    private PlayerControls _controls;
    private bool _canUseInputs = true;
    public event Action EventChestBtn;
    public event Action EventCanceledChestBtn;
    public event Action EventHideEyes;
    public event Action EventShowEyes;
    public event Action EventHandBtn;
    public event Action EventHeadBtn;
    private void Awake()
    {
        _controls = new PlayerControls();

        _controls.Gameplay.chestButton.performed += ctx => ChestBtn();
        _controls.Gameplay.chestButton.canceled += ctx => CanceledChestBtn();
        _controls.Gameplay.eyesButton.performed += ctx => HideEyes();
        _controls.Gameplay.eyesButton.canceled += ctx => ShowEyes();
        _controls.Gameplay.handButton.performed += ctx => HandBtn();
        _controls.Gameplay.headButton.performed += ctx => HeadBtn();
    }

    public void ChestBtn()
    {
        if (_canUseInputs)
        {
            _canUseInputs = false;
            EventChestBtn?.Invoke();
        }
        
    }

    public void CanceledChestBtn()
    {
        EventCanceledChestBtn?.Invoke();
        _canUseInputs = true;
    }

    public void HideEyes()
    {
        if (_canUseInputs)
        {
            EventHideEyes?.Invoke();
        }
    }

    public void ShowEyes()
    {
        if (_canUseInputs)
        {
            EventShowEyes?.Invoke();
        }
    }
    
    public void HandBtn()
    {
        if (_canUseInputs)
        {
            EventHandBtn?.Invoke();
        }
    }
    public void HeadBtn()
    {
        if (_canUseInputs)
        {
            EventHeadBtn?.Invoke();
        }
    }

    private void OnEnable()
    {
        _controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        _controls.Gameplay.Disable();
    }
}
