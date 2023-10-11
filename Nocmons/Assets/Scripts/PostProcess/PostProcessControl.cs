using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessControl : MonoBehaviour
{
    [SerializeField] private BearReference bearRef;
    private Volume _postProcessingVolume;
    [SerializeField] private float vignetteIntensity;
    private Vignette _vignette;
    private BearState _bearState;

    [Header("VignetteParam")] 
    [SerializeField] private float maxVignetteIntensity;

    private void Start()
    {
        _bearState = bearRef.Instance.GetComponent<BearState>();
        _postProcessingVolume = GetComponent<Volume>();
        _postProcessingVolume.profile.TryGet(out _vignette);
    }

    private void Update()
    {
        float fearValue = _bearState.CurrentFearValue;
        float maxFearValue = _bearState.MaxFearValue;
        _vignette.intensity.value = Mathf.Lerp(0, maxVignetteIntensity,fearValue/maxFearValue);
    }
}
