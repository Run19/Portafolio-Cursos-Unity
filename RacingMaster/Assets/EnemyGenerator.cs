using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private GameObject enemy;
    public static EnemyGenerator ShIn;

    private List<GameObject> _enemies = new List<GameObject>();

    private void Awake()
    {
        ShIn = ShIn == null ? this : ShIn;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public void StartGame()
    {
        InvokeRepeating(nameof(GenerateEnemies), 2, 2);
    }

    private void GenerateEnemies()
    {
        var lEnemy = Instantiate(enemy, new Vector3(_player.transform.position.x, transform.position.y),
            Quaternion.Euler(Vector3.zero));
        _enemies.Add(lEnemy);
    }

    public void DestroyAll()
    {
        foreach (var lEnemy in _enemies)
        {
            Destroy(lEnemy.gameObject);
        }

        _enemies.Clear();
        CancelInvoke();
    }
}