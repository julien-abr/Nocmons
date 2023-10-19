using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShadowState : MonoBehaviour
{
    [SerializeField] private EventParameter eventParameter;
    [SerializeField] private BearReference bearRef;
    private BearState _bearState;
    private bool[] rowLeft = new bool[4];
    private bool[] rowMiddle = new bool[4];
    private bool[] rowRight = new bool[4];
    private int _currentPhases;
    
    private bool _usingLight;

    public void Init(int currentPhase)
    {
        _currentPhases = currentPhase;
        _bearState = bearRef.Instance.GetComponent<BearState>();
    }

    public void UpdateCurrentPhase(int phase)
    {
        _currentPhases = phase;
    }

    public void InitSpawnMonster(RotationState spawnRow)
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
        SetActiveMonsterAndUpdateArray(spawnRow, spawnPoint, true);
        MooveMonster(spawnRow, spawnPoint);
    }
    private void MooveMonster(RotationState monsterRow, int index)
    {
        float minSpeed = eventParameter.EventPhases[_currentPhases].shadowParam.minTimeBeforeMoving;
        float maxSpeed = eventParameter.EventPhases[_currentPhases].shadowParam.maxTimeBeforeSpawn;
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        
        StartCoroutine(MoveMonsterCoroutine(randomSpeed));
        IEnumerator MoveMonsterCoroutine(float time)
        {
            yield return new WaitForSeconds(time);
            SetActiveMonsterAndUpdateArray(monsterRow, index, false);
                    
            if (++index < 4)
            {
                //Play Sound & damage
                SetActiveMonsterAndUpdateArray(monsterRow, ++index, true);
                MooveMonster(monsterRow, ++index);
            }
        }
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

    private void SetActiveMonsterAndUpdateArray(RotationState row, int index, bool result)
    {
        switch (row)
        {
            case RotationState.Left:
                switch (index)
                {
                    case 0:
                        eventParameter.shadowSpawnFirst[0].gameObject.SetActive(result);
                        rowLeft[0] = result;
                        break;
                    case 1:
                        eventParameter.shadowSpawnSecond[0].gameObject.SetActive(result);
                        rowLeft[1] = result;
                        break;
                    case 2:
                        eventParameter.shadowSpawnThird[0].gameObject.SetActive(result);
                        rowLeft[2] = result;
                        break;
                    case 3:
                        eventParameter.shadowSpawnFourth[0].gameObject.SetActive(result);
                        rowLeft[3] = result;
                        break;
                }
                break;
            case RotationState.Middle:
                switch (index)
                {
                    case 0:
                        eventParameter.shadowSpawnFirst[1].gameObject.SetActive(result);
                        rowMiddle[0] = result;
                        break;
                    case 1:
                        eventParameter.shadowSpawnSecond[1].gameObject.SetActive(result);
                        rowMiddle[1] = result;
                        break;
                    case 2:
                        eventParameter.shadowSpawnThird[1].gameObject.SetActive(result);
                        rowMiddle[2] = result;
                        break;
                    case 3:
                        eventParameter.shadowSpawnFourth[1].gameObject.SetActive(result);
                        rowMiddle[3] = result;
                        break;
                }
                break;
            case RotationState.Right:
                switch (index)
                {
                    case 0:
                        eventParameter.shadowSpawnFirst[2].gameObject.SetActive(result);
                        rowRight[0] = result;
                        break;
                    case 1:
                        eventParameter.shadowSpawnSecond[2].gameObject.SetActive(result);
                        rowRight[1] = result;
                        break;
                    case 2:
                        eventParameter.shadowSpawnThird[2].gameObject.SetActive(result);
                        rowRight[2] = result;
                        break;
                    case 3:
                        eventParameter.shadowSpawnFourth[2].gameObject.SetActive(result);
                        rowRight[3] = result;
                        break;
                }
                break;
        }
    }

    public void SetUsingLight(bool result)
    {
        _usingLight = result;
    }

    private void Update()
    {
        if (_usingLight)
        {
            SetEnableFalseAllRow(_bearState.CurrentRot);
        }
    }

    private void SetEnableFalseAllRow(RotationState row)
    {
        switch (row)
        {
            case RotationState.Left:
                for (int i = 0; i < rowLeft.Length; i++) { rowLeft[i] = false; }
                for (int i = 0; i < eventParameter.shadowSpawnFirst.Count; i++) { eventParameter.shadowSpawnFirst[i].SetActive(false);}
                break;
            case RotationState.Middle:
                for (int i = 0; i < rowMiddle.Length; i++) { rowMiddle[i] = false; }
                for (int i = 0; i < eventParameter.shadowSpawnSecond.Count; i++) { eventParameter.shadowSpawnFirst[i].SetActive(false);}
                break;
            case RotationState.Right:
                for (int i = 0; i < rowRight.Length; i++) { rowRight[i] = false; }
                for (int i = 0; i < eventParameter.shadowSpawnThird.Count; i++) { eventParameter.shadowSpawnFirst[i].SetActive(false);}
                break;
        }
    }
}
