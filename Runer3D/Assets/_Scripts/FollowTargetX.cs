using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetX : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField, Range(-20, 20)] private float offset;

    private void Update()
    {
        var position = transform.position;
        transform.position = new Vector3(target.transform.position.x + offset, position.y, position.z);
    }
}