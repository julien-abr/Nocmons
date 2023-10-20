using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Environment : MonoBehaviour
{


    [Header("Base Gradient Environment")]
    [SerializeField] Color _skyColor;
    [SerializeField] Color _equatorColor;
    [SerializeField] Color _groundColor;

    [Header("Thunder Gradient Environment")]
    [SerializeField] Color _tunderSkyColor;
    [SerializeField] Color _thunderEquatorColor;
    [SerializeField] Color _thunderEroundColor;

    [Header("Stats")]
    [SerializeField] float _lightingDuration;
    [SerializeField] AnimationCurve _lightingIntensityOverTime;
    void Start(){
        ColorStart();
    }

    //t
    [ContextMenu("thunder")]

    void t()
    {
        StartCoroutine(EnvironmentThunder());
    }
    public IEnumerator EnvironmentThunder()
    {

        float _duration = 0f;

        while (_duration < _lightingDuration)
        {
            float _ratio = (_duration / _lightingDuration);
            Color _sky = _skyColor * _ratio + _tunderSkyColor * (1 - _ratio);
            Color _equator = _equatorColor * _ratio + _thunderEquatorColor * (1 - _ratio);
            Color _ground = _groundColor * _ratio + _thunderEroundColor * (1 - _ratio);

            RenderSettings.ambientSkyColor = _sky;
            RenderSettings.ambientEquatorColor = _equator;
            RenderSettings.ambientGroundColor = _ground;

            _duration += Time.deltaTime;
            yield return null;
        }

        yield return null;
    }

    [ContextMenu("trestons les couleurs")]
    void ColorStart(){
        RenderSettings.ambientSkyColor = _skyColor;
        RenderSettings.ambientEquatorColor = _equatorColor;
        RenderSettings.ambientGroundColor = _groundColor;
    }
}
