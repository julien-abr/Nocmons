using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject target;

    private bool IsVisible(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }

        }
        return true;
    }


    private void Update()
    {
        var targetRenderer = target.GetComponent<MeshRenderer>();
        if (IsVisible(_camera, target))
        {
            targetRenderer.material.SetColor("_Color", Color.red);
        }
        else
        {
            targetRenderer.material.SetColor("_Color", Color.green);

        }
    }
}
