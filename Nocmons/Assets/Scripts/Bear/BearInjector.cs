using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BearInjector : MonoBehaviour
{
    [SerializeField] BearReference _ref;

    ISet<GameObject> RealRef => _ref;

    void Awake()
    {
        RealRef.Set(this.gameObject);
    }
}