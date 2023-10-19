using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowState : MonoBehaviour
{
    [SerializeField] private EventParameter eventParameter;
    private bool[] rowLeft = new bool[4];
    private bool[] rowMiddle = new bool[4];
    private bool[] rowRight = new bool[4];
    private int _currentPhases;

    private void InitSpawnMonster(RotationState spawnRow)
    {
        if (isRowEmpty(spawnRow))
        {
            SpawnMonster(spawnRow);
        }
    }

    private void SpawnMonster(RotationState spawnRow)
    {
        var listSpawnPoint = eventParameter.EventPhases[_currentPhases].shadowParam.shadowSpawnPoint;
        int spawnPoint = Random.Range(0, listSpawnPoint.Count);
        switch (spawnRow)
        {
            case RotationState.Left:
                //if()
                break;
            case RotationState.Middle:
                break;
            case RotationState.Right:
                break;
        }
    }

    private void MooveMonster(RotationState monsterRow, int index)
    {
        
        
        /*StartCoroutine(MoveMonsterCoroutine());
        IEnumerator MoveMonsterCoroutine()
        {
            
        }*/
    }

    private bool isRowEmpty(RotationState spawnRow)
    {
        bool isEmpty = true;
        
        switch (spawnRow)
        {
            case RotationState.Left:
                foreach (var b in rowLeft) { if (b == true) { return false; } }
                break;
            case RotationState.Middle:
                foreach (var b in rowMiddle) { if (b == true) { return false; } }
                break;
            case RotationState.Right:
                foreach (var b in rowRight) { if (b == true) { return false; } }
                break;
        }

        return true;
    }
}
