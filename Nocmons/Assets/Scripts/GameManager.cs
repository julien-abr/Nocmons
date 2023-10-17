using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;

    void Start()
    {
        eventManager.Init();
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);
    }
    
}
