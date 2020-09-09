using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private float _horizontalInput;


    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, _horizontalInput * rotationSpeed * Time.deltaTime);
    }
}