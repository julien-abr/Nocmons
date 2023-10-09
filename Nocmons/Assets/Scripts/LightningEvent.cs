using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightningEvent : MonoBehaviour
{
    [SerializeField] private GameObject _tunder;
    [SerializeField] private int _tunderDuration;
    private bool _tunderIsActive;
    private bool _bearInteraction;

    InputMaster _controls;

    private void Awake()
    {
        _controls = new InputMaster();
        _controls.Player.handButton.performed += ctx => HandButtonPressed();
    }

    void Start()
    {
        _tunderIsActive = false;
        _bearInteraction = false;
        StartCoroutine(LaunchTunder());
    }
    
    void HandButtonPressed()
    {
        if (_tunderIsActive == true)
        {
            _bearInteraction = true;
            Debug.Log(("j'ai appuyé sur le super bouton pour les mains"));
        }
        
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    IEnumerator LaunchTunder()
    {
        _tunderIsActive = true;
        yield return new WaitForSeconds(_tunderDuration);
        _tunderIsActive = false;
        if (_bearInteraction == false && _tunderIsActive == false)
        {
            Debug.Log("tu as super peur car tu as pas cacher les yeux du nounours");
        }
    }
}
