using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private Transform targetObject; 
    [SerializeField] private float moveSpeed = 5.0f; 

    private Vector3 startPosition;
    private bool isMoving = false;
    
    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget());
        }

        if (gameObject.transform.position == targetObject.position)
        {
            //le player prend de la peur 
            Destroy(gameObject);
        }
    }
    
    private IEnumerator MoveToTarget()
    {
        isMoving = true;
        float journeyLength = Vector3.Distance(startPosition, targetObject.position);
        float startTime = Time.time;

        while (transform.position != targetObject.position)
        {
            float distanceCovered = (Time.time - startTime) * moveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetObject.position, journeyFraction);
            yield return null;
        }
        isMoving = false;
    }
}
