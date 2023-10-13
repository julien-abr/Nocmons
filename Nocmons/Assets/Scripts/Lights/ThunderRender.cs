using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Light))]

public class ThunderRender : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private AnimationCurve _lightingIntensityOverTime;
    [SerializeField] private float _lightingDuration;
    [Range(0f, 200f)]
    [SerializeField] private float _lightingIntensity;
    [SerializeField] private List<Texture2D> _texturesPossiblesList;
    private LightningEvent lightningEvent;
    
    
    [ContextMenu("Cast some lightings")]
    private void CastLightingFrommInstpector()
    {
        lightningEvent = GetComponent<LightningEvent>();
        LightningEffect();
    }

    private void Start()
    {
        lightningEvent = GetComponent<LightningEvent>();
    }

    public void LightningEffect()
    {
        StartCoroutine(CastLighting());
        
        IEnumerator CastLighting()
        {
            light.enabled = true;
            
            float _duration = 0f;

            //une texture al�atoire
            GetComponent<Light>().cookie = _texturesPossiblesList[Random.Range(0, _texturesPossiblesList.Count - 1)];

            while (_duration < _lightingDuration)
            {
                _duration += Time.deltaTime;
                GetComponent<Light>().intensity = _lightingIntensityOverTime.Evaluate(_duration/_lightingDuration) * _lightingIntensity;
                
                yield return null;
            }

            GetComponent<Light>().intensity = 0;

            lightningEvent.EffectEnded();
            yield return null;
        }
    }



}
