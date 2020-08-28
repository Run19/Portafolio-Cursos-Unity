using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{


    [SerializeField]
    private float velocity, maxPos = 2560, initialPosition = 512f;
    [SerializeField]



    void Update()
    {

            if (this.transform.position.x < maxPos)
            {
                this.transform.position = new Vector3(this.transform.position.x + velocity * Time.deltaTime, transform.position.y);
            }
            else
            {
                this.transform.position = new Vector3(initialPosition, transform.position.y);
            }
        

    }
}
