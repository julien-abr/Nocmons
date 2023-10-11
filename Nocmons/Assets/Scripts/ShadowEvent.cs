using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEvent : Event
{
    [SerializeField] private BearReference bearRef;
    private void Start()
    {
        //Take event that we need;
        BearActions actions = bearRef.Instance.GetComponent<BearActions>();
        actions.EventHandBtn += Test;
    }

    private void Test()
    {
        Debug.Log("Pressed P");
    }
}
