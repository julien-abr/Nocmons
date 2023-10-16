using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> _differentPlanksPossible;
    [SerializeField] float _width;
    [SerializeField] float _height;
    [SerializeField] float _planksScale =.1f;
    Vector2 _plankDimention = new Vector2(5.425f, 53.89f);

    [ContextMenu("Genere moi un beau parquet")]
    void PlanksGenerator()
    {
        GameObject _parent = Instantiate(new GameObject());
        _parent.transform.parent = gameObject.transform;
        int _row = 0;
        for(float _generatorWidth = 0; _generatorWidth < _width; _generatorWidth+= _plankDimention.x * _planksScale)
        {
            _row++;
            for (float _generatorHeight = 0; _generatorHeight < _height; _generatorHeight += _plankDimention.y * _planksScale)
            {
                GameObject _plank = Instantiate(_differentPlanksPossible[Random.Range(0, _differentPlanksPossible.Count)], new Vector3(transform.position.x + _generatorWidth , transform.position.y,transform.position.z + _generatorHeight + (_row%2*(_plankDimention.y * _planksScale / 2))), Quaternion.Euler(new Vector3(0,180*Random.Range(0,2),0)));
                _plank.transform.localScale = new Vector3(_planksScale, _planksScale, _planksScale);
                _plank.transform.parent = _parent.transform;
            }
        }
    }

    private void OnDrawGizmos()
    {
        //diagonale
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _width, transform.position.y, transform.position.z + _height));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + _width, transform.position.y, transform.position.z));
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + _height));
    }
}
