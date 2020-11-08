using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Collections;
using UnityEngine;

public class AnimalBehavior : MonoBehaviour
{
    [SerializeField] private DogObject stats;
    private GameObject _player;
    private static readonly Vector3 OffsetPlayer = new Vector3(0, 0, 10f);
    private const float DeadZone = -9.0f;
    private bool _followingPlayer;
    private float _currentLife;
    
 
    private void Awake()
    {

        _currentLife = stats.life;
        _followingPlayer = true;
        _player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    private void Update()
    {
        var currentVelocity = stats.velocity * Time.deltaTime;
        if (transform.position.z > _player.transform.position.z - OffsetPlayer.z / 2 && _followingPlayer)
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position - OffsetPlayer,
                currentVelocity);
        else
        {
            _followingPlayer = false;
            transform.Translate(0, 0, currentVelocity );
        }

        if (_currentLife <= 0 || transform.position.z < DeadZone)
            Destroy(gameObject);
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Food"))
        {
            Destroy(other.gameObject);
            BeDamaged(other.GetComponent<FoodMove>().GetDamage());
        }   
    }

    private void BeDamaged(int damage)
    {
        _currentLife -= damage;
    }

    public int GetDamageDone()
    {
        return stats.damage;
    }
}