using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private float velocity;
    void Update()
    {
        transform.Translate(0,-velocity*Time.deltaTime,0);
    }
}
