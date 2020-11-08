using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "FoodStats",menuName = "Food/FoodStats")]
public class FoodStats : ScriptableObject
{
    public float velocity;
    public int damage;
}
