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

    PlayerControls _controls;

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Gameplay.eyesButton.performed += ctx => HandButtonPressed();
    }

    void Start()
    {
        _tunder.SetActive(false);
        _tunderIsActive = false;
        _bearInteraction = false;
        StartCoroutine(LaunchTunder());
    }
    
    void HandButtonPressed()
    {
        if (_tunderIsActive == true)
        {
            _bearInteraction = true;
            Debug.Log(("j'ai appuyé sur le super bouton pour les yeux"));
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

    IEnumerator LaunchTunder()
    {
        _tunderIsActive = true;
        _tunder.SetActive(_tunderIsActive);
        yield return new WaitForSeconds(_tunderDuration);
        _tunderIsActive = false;
        _tunder.SetActive(_tunderIsActive);
        if (_bearInteraction == false && _tunderIsActive == false)
        {
            Debug.Log("tu as super peur car tu as pas cacher les yeux du nounours");
        }
    }
}
