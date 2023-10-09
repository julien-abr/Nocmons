using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEvent : MonoBehaviour
{
    [SerializeField] private GameObject _tunder;
    [SerializeField] private int _tunderDuration;
    private bool _tunderIsActive;
    private bool _bearInteraction;
    void Start()
    {
        _tunderIsActive = false;
        _bearInteraction = false;
        StartCoroutine(LaunchTunder());
    }
    
    void Update()
    {
        if (_tunderIsActive == true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _bearInteraction = true;
            }
        }
    }

    IEnumerator LaunchTunder()
    {
        _tunderIsActive = true;
        yield return new WaitForSeconds(_tunderDuration);
        _tunderIsActive = false;
        if (_bearInteraction == false && _tunderIsActive == false)
        {
            //take damage
        }
    }
}
