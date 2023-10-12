using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMovement : MonoBehaviour
{
    [SerializeField] private Transform targetObject; 
    public float moveSpeed = 5.0f;
    public float actualMoveSpeed;
    private Vector3 startPosition;
    private bool isMoving = false;
    public bool cantMove;
    
    private void Start()
    {
        actualMoveSpeed = moveSpeed;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveToTarget());
        }
        if(cantMove == true)
        {
            StopCoroutine(MoveToTarget());
        }

        if (gameObject.transform.position == targetObject.position)
        {
            //le player prend de la peur 
            Destroy(gameObject);
        }
    }
    
    public IEnumerator MoveToTarget()
    {
        isMoving = true;
        float journeyLength = Vector3.Distance(gameObject.transform.position, targetObject.position);
        float startTime = Time.time;

        while (transform.position != targetObject.position)
        {
            float distanceCovered = (Time.time - startTime) * actualMoveSpeed;
            float journeyFraction = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetObject.position, journeyFraction);
            yield return null;
        }
        isMoving = false;
    }
}
