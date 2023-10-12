using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;



public class cameraMovement : MonoBehaviour
{
    PlayerControls _controls;
    [SerializeField] private GameObject _camera;
    [SerializeField] private float _timeToRotate;
    
    [SerializeField] private Vector3 _cameraLeft;
    [SerializeField] private Vector3 _cameraMidle;
    [SerializeField] private Vector3 _cameraRight;
    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Gameplay.RotateCamLeft.performed += ctx => RotateCameLeft();
        _controls.Gameplay.RotateCamMidle.performed += ctx => RotateCameMidle();
        _controls.Gameplay.RotateCamRight.performed += ctx => RotateCameRight();
    }
    
    void RotateCameLeft()
    {
        _camera.transform.DORotate(_cameraLeft, _timeToRotate, RotateMode.Fast);
    }
    void RotateCameRight()
    {
        _camera.transform.DORotate(_cameraRight, _timeToRotate, RotateMode.Fast);

    }
    void RotateCameMidle()
    {
        _camera.transform.DORotate(_cameraMidle, _timeToRotate, RotateMode.Fast);

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
