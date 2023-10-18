using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool _oneShot;

    private void Start()
    {
        AudioManager.instance.Play("MenuMusic");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!_oneShot)
            {
                AudioManager.instance.StopMusic("MenuMusic");
                AudioManager.instance.Play("PressAnyButton");
                AudioManager.instance.Play("BedRoomMusic1");
                SceneManager.LoadScene("Julien");
                _oneShot = true;
            }
        }
    }
}
