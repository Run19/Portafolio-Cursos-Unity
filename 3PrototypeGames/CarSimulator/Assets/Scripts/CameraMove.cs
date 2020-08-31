using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField,Tooltip("Distance Between target and camera")] private Vector3 cameraOffset;
    void Update()
    {
        transform.position = target.transform.position + cameraOffset;
    }
}
