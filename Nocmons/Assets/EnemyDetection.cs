using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private BearReference bearRef;
    private List<DetectionStruct> listDetection = new List<DetectionStruct>();
    private LightSystem _lightSystem;
    public bool _isUsingLight;

    private void Start()
    {
        _lightSystem = bearRef.Instance.GetComponent<LightSystem>();
        _lightSystem.OnLightActivate += LightOn;
        _lightSystem.OnLightDeactivate += LightOff;
    }
    
    public void AddObject(GameObject go)
    {
        DetectionStruct newDetection = new DetectionStruct();
        newDetection.GoToDetect = go;
        newDetection.Movement = newDetection.GoToDetect.GetComponent<ShadowMovementV2>();
        listDetection.Add(newDetection);
    }

    public void RemoveObject(GameObject go)
    {
        DetectionStruct structToRemove = new DetectionStruct();
        foreach (DetectionStruct detectionStruct in listDetection)
        {
            if (detectionStruct.GoToDetect == go)
            {
                structToRemove = detectionStruct;
            }
        }

        listDetection.Remove(structToRemove);
    }

    private void Update()
    {
        if (listDetection.Count == 0 || camera == null)
        {
            return;
        }

        foreach (DetectionStruct detectionStruct in listDetection)
        {
            Vector3 screenPoint = camera.WorldToScreenPoint(detectionStruct.GoToDetect.transform.position);

            if (screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < Screen.width && screenPoint.y > 0 &&
                screenPoint.y < Screen.height)
            {
                detectionStruct.Movement.SetIsSeen(true);
            }
            else
            {
                detectionStruct.Movement.SetIsSeen(false);
            }
        }

    }

    private void LightOn()
    {
        _isUsingLight = true;
        foreach (DetectionStruct detectionStruct in listDetection)
        {
            detectionStruct.Movement.SetUsingLight(true);
        }
    }
    
    private void LightOff()
    {   
        _isUsingLight = false;
        
        foreach (DetectionStruct detectionStruct in listDetection)
        {
            detectionStruct.Movement.SetUsingLight(false);
        }
    }

}
struct DetectionStruct
{
    public GameObject GoToDetect;
    public ShadowMovementV2 Movement;
}
