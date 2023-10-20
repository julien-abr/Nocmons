using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BearActions : MonoBehaviour, IBearActions
{
    [SerializeField] private BearReference _bearReference;
    private PlayerControls _controls;
    private bool _canUseInputs = true;
    private bool _isDie = false;
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

        _bearReference.Instance.GetComponent<BearState>().OnDied += Dead;
        _controls.Gameplay.chestButton.performed += ctx => ChestBtn();
        _controls.Gameplay.chestButton.canceled += ctx => CanceledChestBtn();
        _controls.Gameplay.eyesLeftButton.performed += ctx => HideLeftEye();
        _controls.Gameplay.eyesRightButton.performed += ctx => HideRightEye();
        _controls.Gameplay.eyesLeftButton.canceled += ctx => ShowLeftEye();
        _controls.Gameplay.eyesRightButton.canceled += ctx => ShowRightEye();
        _controls.Gameplay.handButton.performed += ctx => HandBtn();
        _controls.Gameplay.headButton.performed += ctx => HeadBtn();
        _controls.Gameplay.RotateCamLeft.performed += ctx => CamRotLeft();
        _controls.Gameplay.RotateCamRight.performed += ctx => CamRotRight();
        _controls.Gameplay.RotateCamMidle.performed += ctx => CamRotMiddle();
    }

    public void ChestBtn()
    {
        if (_canUseInputs && !_isDie)
        {
            _canUseInputs = false;
            EventChestBtn?.Invoke();
            AudioManager.instance.PlayRandom(SoundState.FROTTEMENT);
        }
        
    }

    public void CanceledChestBtn()
    {
        if (!_isDie)
        {
            EventCanceledChestBtn?.Invoke();
            _canUseInputs = true;  
        }
        
    }

    public void HideLeftEye()
    {
        if (_canUseInputs && !_isDie)
        {
            EventHideLeftEye?.Invoke();
        }
    }
    
    public void HideRightEye()
    {
        if (_canUseInputs && !_isDie)
        {
            EventHideRightEye?.Invoke();
        }
    }

    public void ShowLeftEye()
    {
        if (_canUseInputs && !_isDie)
        {
            EventShowLeftEye?.Invoke();
        }
    }
    
    public void ShowRightEye()
    {
        if (_canUseInputs && !_isDie)
        {
            EventShowRightEye?.Invoke();
        }
    }

    public void HandBtn()
    {
        if (_canUseInputs && !_isDie)
        {
            EventHandBtn?.Invoke();
        }
    }
    public void HeadBtn()
    {
        if (_canUseInputs && !_isDie)
        {
            EventHeadBtn?.Invoke();
            AudioManager.instance.PlayRandom(SoundState.HEAD);
        }
    }

    public void CamRotLeft()
    {
        if (_canUseInputs && !_isDie)
        {
            EventCamRotateLeft?.Invoke();
        }
    }

    public void CamRotRight()
    {
        if (_canUseInputs && !_isDie)
        {
            EventCamRotateRight?.Invoke();
        }
    }

    public void CamRotMiddle()
    {
        if (_canUseInputs && !_isDie)
        {
            EventCamRotateMiddle?.Invoke();
        }
    }

    public void Dead()
    {
        _isDie = false;
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
