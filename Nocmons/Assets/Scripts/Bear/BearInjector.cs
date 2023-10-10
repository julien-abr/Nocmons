using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BearInjector : MonoBehaviour
{
    [SerializeField] BearActions _e;
    [SerializeField] BearReference _ref;

    ISet<BearActions> RealRef => _ref;

    void Awake()
    {
        RealRef.Set(_e);
    }

}