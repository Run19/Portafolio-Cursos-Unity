﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class CameraLimits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CameraMove>()
            .changeCameraLimits(GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
