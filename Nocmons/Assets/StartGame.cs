using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private bool _oneShot;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!_oneShot)
            {
                SceneManager.LoadScene("Julien");
                _oneShot = true;
            }
        }
    }
}
