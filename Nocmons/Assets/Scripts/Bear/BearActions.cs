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
    public event Action EventHideLeftEye;
    public event Action EventHideRightEye;
    public event Action EventShowLeftEye;
    public event Action EventShowRightEye;
    public event Action EventHandBtn;
    public event Action EventHeadBtn;
    public event Action EventCamRotateLeft;
    public event Action EventCamRotateMiddle;
    public event Action EventCamRotateRight;
    private void Awake()
    {
        _controls = new PlayerControls();

        _controls.Gameplay.chestButton.performed += ctx => ChestBtn();
        _controls.Gameplay.chestButton.canceled += ctx => CanceledChestBtn();
        _controls.Gameplay.eyesLeftButton.performed += ctx => ShowLeftEye();
        _controls.Gameplay.eyesRightButton.performed += ctx => ShowRightEye();
        _controls.Gameplay.eyesLeftButton.canceled += ctx => HideLeftEye();
        _controls.Gameplay.eyesRightButton.canceled += ctx => HideRightEye();
        _controls.Gameplay.handButton.performed += ctx => HandBtn();
        _controls.Gameplay.headButton.performed += ctx => HeadBtn();
        _controls.Gameplay.RotateCamLeft.performed += ctx => CamRotLeft();
        _controls.Gameplay.RotateCamRight.performed += ctx => CamRotRight();
        _controls.Gameplay.RotateCamMidle.performed += ctx => CamRotMiddle();
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

    public void HideLeftEye()
    {
        if (_canUseInputs)
        {
            EventHideLeftEye?.Invoke();
        }
    }
    
    public void HideRightEye()
    {
        if (_canUseInputs)
        {
            EventHideRightEye?.Invoke();
        }
    }

    public void ShowLeftEye()
    {
        if (_canUseInputs)
        {
            EventShowLeftEye?.Invoke();
        }
    }
    
    public void ShowRightEye()
    {
        if (_canUseInputs)
        {
            EventShowRightEye?.Invoke();
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

    public void CamRotLeft()
    {
        if (_canUseInputs)
        {
            EventCamRotateLeft?.Invoke();
        }
    }

    public void CamRotRight()
    {
        if (_canUseInputs)
        {
            EventCamRotateRight?.Invoke();
        }
    }

    public void CamRotMiddle()
    {
        if (_canUseInputs)
        {
            EventCamRotateMiddle?.Invoke();
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
