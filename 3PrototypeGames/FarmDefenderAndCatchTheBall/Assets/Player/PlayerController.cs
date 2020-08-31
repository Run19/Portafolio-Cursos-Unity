using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    private PlayerControll _control;
    private Vector2 _move;
    [SerializeField, Range(0, 20)] private float velocity, velocityUp;
    private float _currentVelocity;

    [SerializeField, Tooltip("x: Min value y: Max Value")]
    private Vector2 yRange;

    [SerializeField] private float xRange;
    [SerializeField] GameObject[] projectiles = new GameObject[1];
    private bool _atacking, _isInmune;
    [SerializeField, Range(0, 1)] private float initialTimeBetweenFire;
    private float _timeBetweenFire;
    [SerializeField] private int life;
    private int _initiaLife;

    private void Awake()
    {
        //Set Initial Values
        _initiaLife = life;
        _currentVelocity = velocity;
        _timeBetweenFire = initialTimeBetweenFire;
        _control = new PlayerControll();
        //Config Controls
        _control.Player.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
        _control.Player.Move.canceled += ctx => _move = Vector2.zero;
        _control.Player.Attack.performed += ctx => _atacking = true;
        _control.Player.Attack.canceled += ctx => _atacking = false;
        _control.Player.MoveFaster.performed += ctx => SetVelocity(velocityUp);
        _control.Player.MoveFaster.canceled += ctx => SetVelocity(velocity);
    }

    void Update()
    {
        //Movement
        transform.Translate(_move.x * Time.deltaTime * _currentVelocity, 0,
            _move.y * Time.deltaTime * _currentVelocity);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange),
            transform.position.y,
            Mathf.Clamp(transform.position.z, yRange.x, yRange.y));
        //Fire
        if (_timeBetweenFire < 0 && _atacking)
        {
            Attack();
            _timeBetweenFire = initialTimeBetweenFire;
        }
        else if (_timeBetweenFire > 0)
            _timeBetweenFire -= Time.deltaTime;
    }

    private void OnEnable()
    {
        _control.Player.Enable();
    }

    private void OnDisable()
    {
        _control.Player.Disable();
    }

    private void Attack()
    {
        Instantiate(projectiles[Random.Range(0, 1.0f) > 0.7f ? 0 : 1], transform.position + new Vector3(0, 0.5f, 0),
            Quaternion.Euler(Vector3.zero));
    }

    private void SetVelocity(float newVelocity)
    {
        _currentVelocity = newVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Enemy") && !_isInmune)
        {
            Debug.Log("BeingDamaged");
            StartCoroutine(PlayerDamaged(other.GetComponent<AnimalBehavior>().GetDamageDone()));
        }
    }

    private IEnumerator PlayerDamaged(int damage)
    {
        _isInmune = true;
        life -= damage;
        if (life < 0)
            Destroy(gameObject);
        yield return new WaitForSeconds(0.5f);
        _isInmune = false;
    }
}