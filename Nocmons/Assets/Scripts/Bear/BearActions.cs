using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BearActions : MonoBehaviour, IBearActions
{
    private PlayerControls _controls;

    public event Action EventChestBtn;
    public event Action EventHideEyes;
    public event Action EventShowEyes;
    public event Action EventHandBtn;
    public event Action EventHeadBtn;
    private void Awake()
    {
        _controls = new PlayerControls();

        _controls.Gameplay.chestButton.performed += ctx => ChestBtn();
        _controls.Gameplay.eyesButton.performed += ctx => HideEyes();
        _controls.Gameplay.eyesButton.canceled += ctx => ShowEyes();
        _controls.Gameplay.handButton.performed += ctx => HandBtn();
        _controls.Gameplay.headButton.performed += ctx => HeadBtn();
    }

    public void ChestBtn()
    {
        EventChestBtn?.Invoke();
    }

    public void HideEyes()
    {
        EventHideEyes?.Invoke();
    }

    public void ShowEyes()
    {
        EventShowEyes?.Invoke();
    }
    
    public void HandBtn()
    {
        EventHandBtn?.Invoke();
    }
    public void HeadBtn()
    {
        EventHeadBtn?.Invoke();
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