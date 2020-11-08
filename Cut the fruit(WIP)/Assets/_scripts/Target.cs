using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Random = UnityEngine.Random;


public enum TargetType
{
    Bomb,
    PowerUp,
    Fruit
}

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    [SerializeField] private TargetType targetType;
    private Rigidbody _rigidbody;
    [SerializeField, Min(5)] private float minImpulseForce, maxImpulseForce;
    [SerializeField, Min(3)] private float minTorqueForce, maxTorqueForce;
    private readonly List<GameObject> _particles = new List<GameObject>();
    [SerializeField, Range(0, 50)] private int value;
    private bool _canSum;


    private void Awake()
    {
        _canSum = true;
        for (var i = 0; i < transform.childCount; i++)
            if (transform.GetChild(i).GetComponent<ParticleSystem>() != null)
                _particles.Add(transform.GetChild(i).gameObject);

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AddForces();
    }

    private void AddForces()
    {
        _rigidbody.AddForce(Vector3.up * Random.Range(minImpulseForce, maxImpulseForce), ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.up * Random.Range(minTorqueForce, maxTorqueForce), ForceMode.Impulse);
        _rigidbody.AddTorque(Vector3.left * Random.Range(minTorqueForce, maxTorqueForce), ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("knife") || other.CompareTag("Destroyer")))
            return;

        if (other.CompareTag("knife"))
            Die();


        if (other.CompareTag("Destroyer"))
            Destroy(gameObject);
    }


    private void Die()
    {
        DestroySelf();
        SetPlayerValues();
    }

    private void DestroySelf()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        _particles[Random.Range(0, _particles.Count)].SetActive(true);
        Destroy(gameObject, 3);
    }


    private void SetPlayerValues()
    {
        switch (targetType)
        {
            case TargetType.PowerUp:
                GameManager.SingleInstance.ChangeLife(true);
                GameManager.SingleInstance.ChangeLife(true);
                Time.timeScale = Time.timeScale >= 1.1f ? Time.timeScale - 0.05f : Time.timeScale;
                return;
            case TargetType.Bomb:
                GameManager.SingleInstance.ChangeLife(false);
                break;
            case TargetType.Fruit:
                GameManager.SingleInstance.ChangeLife(true,
                    GameManager.SingleInstance.GetLife() >= 3.0f ? 0.0f : 0.025f);
                break;
        }

        if (!_canSum) return;
        _canSum = false;
        GameManager.SingleInstance.SetScore(targetType == TargetType.Fruit, value);
        GUIManager.SingleInstance.UpdateScore();
    }
}