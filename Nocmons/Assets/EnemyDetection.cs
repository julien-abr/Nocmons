using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private BearReference bearRef;
    private List<DetectionStruct> listDetection = new List<DetectionStruct>();
    // [SerializeField] private l
    
    public void AddObject(GameObject go)
    {
        DetectionStruct newDetection = new DetectionStruct();
        newDetection.GoToDetect = go;
        newDetection.Movement = newDetection.GoToDetect.GetComponent<ShadowMovementV2>();
        listDetection.Add(newDetection);
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

}
struct DetectionStruct
{
    public GameObject GoToDetect;
    public ShadowMovementV2 Movement;
}
