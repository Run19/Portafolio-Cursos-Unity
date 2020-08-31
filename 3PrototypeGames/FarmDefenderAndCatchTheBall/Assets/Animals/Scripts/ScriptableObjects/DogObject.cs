using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies/Dog")]
public class DogObject : ScriptableObject
{
    public int damage;
    public float velocity;
    public int life;
}