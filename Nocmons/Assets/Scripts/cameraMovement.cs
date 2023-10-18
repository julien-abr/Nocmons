using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.InputSystem;



public class cameraMovement : MonoBehaviour
{
    [SerializeField] private BearReference bearRef;
    [SerializeField] private EventParameter eventParameter;
    private GameObject camera;
    private float _timeToRotate;
    
    private Vector3 _cameraLeft;
    private Vector3 _cameraMiddle;
    private Vector3 _cameraRight;

    private BearActions _bearActions;

    private void Start()
    {
        camera = this.gameObject;
        _bearActions = bearRef.Instance.GetComponent<BearActions>();
        _bearActions.EventCamRotateLeft += RotateCameLeft;
        _bearActions.EventCamRotateMiddle += RotateCameMiddle;
        _bearActions.EventCamRotateRight += RotateCameRight;
        _timeToRotate = eventParameter.cameraRotateSpeed;
        _cameraLeft = eventParameter.cameraLeft;
        _cameraRight = eventParameter.cameraRight;
        _cameraMiddle = eventParameter.cameraMiddle;
    }

    public void RotateCameLeft()
    {
        camera.transform.DORotate(_cameraLeft, _timeToRotate, RotateMode.Fast);
    }
    public void RotateCameRight()
    {
        camera.transform.DORotate(_cameraRight, _timeToRotate, RotateMode.Fast);

    }
    public void RotateCameMiddle()
    {
        camera.transform.DORotate(_cameraMiddle, _timeToRotate, RotateMode.Fast);
    }
}
