using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]

public class ThunderRender : MonoBehaviour
{
    [SerializeField] private AnimationCurve _lightingIntensityOverTime;
    [SerializeField] private float _lightingDuration;
    [Range(0f, 200f)]
    [SerializeField] private float _lightingIntensity;
    [SerializeField] private List<Texture2D> _texturesPossiblesList;

    bool _t;
    float _duration = 0;
    [ContextMenu("Cast some lightings")]
    private void CastLightingFrommInstpector()
    {
        StartCoroutine(CastLighting());
    }
    
    public IEnumerator CastLighting()
    {
        float _duration = 0f;

        //une texture aléatoire
        GetComponent<Light>().cookie = _texturesPossiblesList[Random.Range(0, _texturesPossiblesList.Count - 1)];

        while (_duration < _lightingDuration)
        {
            _duration += Time.deltaTime;
            GetComponent<Light>().intensity = _lightingIntensityOverTime.Evaluate(_duration/_lightingDuration) * _lightingIntensity;


            yield return null;
        }

        GetComponent<Light>().intensity = 0;
        yield return null;
    }


}
