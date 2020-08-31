using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BarrelScript : MonoBehaviour
{
    [SerializeField, Tooltip("Velocity of move")]
    private float velocity;

    private Rigidbody _playerRigidBody;

    private void Awake()
    {
        foreach (var obstacle in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Physics.IgnoreCollision(obstacle.GetComponent<Collider>(), GetComponent<Collider>());
        }

        _playerRigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _playerRigidBody.AddForce(Vector3.left * velocity, ForceMode.VelocityChange);
    }
}