using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHideObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> _objectsLink;
    private void OnEnable()
    {
        for(int _objects = 0; _objects < _objectsLink.Count; _objects++)
        {
            _objectsLink[_objects].SetActive(false);
        }
    }
    private void OnDisable()
    {
        for (int _objects = 0; _objects < _objectsLink.Count; _objects++)
        {
            _objectsLink[_objects].SetActive(true);
        }
    }
}
