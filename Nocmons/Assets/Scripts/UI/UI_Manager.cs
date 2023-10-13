using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private BearReference bearReference;
    [SerializeField] private TMP_Text game_Text;

    private BearState bearState;
    private void Start()
    {
        bearState = bearReference.Instance.GetComponent<BearState>();
        bearState.OnDied += OnLoose;
        bearState.OnWin += OnWin;
    }

    private void OnWin()
    {
        game_Text.text = "You Win !";
    }

    private void OnLoose()
    {
        game_Text.text = "You Loose !";
    }
}
