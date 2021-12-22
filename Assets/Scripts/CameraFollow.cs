using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] public Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed = 0f;

    private float extraRotation;

    private void FixedUpdate(){
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation(){
        // Change here
        // Turn camera 180 degrees and position behind prefab
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }

    private void HandleRotation() {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up); 
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
