using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    [SerializeField] private FoodStats foodStats;
    private const float MaxPos = 34;


    void Update()
    {
        transform.Translate(Vector3.forward * foodStats.velocity * Time.deltaTime);
        if (transform.position.z > MaxPos)
        {
            Destroy(gameObject);
        }
    }


    public int GetDamage()
    {
        return foodStats.damage;
    }
}