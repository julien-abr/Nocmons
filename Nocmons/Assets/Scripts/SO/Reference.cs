using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISet<T>
{
    void Set(T value);
}

public class Reference<T> : ScriptableObject, ISet<T>
{
    T _instance;

    public T Instance { get => _instance;}

    void ISet<T>.Set(T value)
    {
        _instance = value;
    }
}

