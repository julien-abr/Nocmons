using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EventManager eventManager;
    void Start()
    {
        eventManager.Init();
    }
    
}
