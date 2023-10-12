using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject target;

    public ShadowMovementV2 _shadowMovement;
    

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
        _shadowMovement._actualEnemySpeed = 0;
        Debug.Log("lala");
    }

    private void CanMove()
    {
        _shadowMovement._actualEnemySpeed = _shadowMovement._enemySpeed;
        Debug.Log("lolo");

    }
}
