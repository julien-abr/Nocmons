using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject target;

    public ShadowMovement _shadowMovement;
    

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
        
        if (IsVisible(_camera, target))
        {
            CanMove();
        }
        else
        {
            CantMove();
        }
    }

    private void CantMove()
    {
        _shadowMovement.actualMoveSpeed = 0;
    }

    private void CanMove()
    {
        _shadowMovement.actualMoveSpeed = _shadowMovement.moveSpeed;

    }
}
