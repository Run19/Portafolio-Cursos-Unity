using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private float timeToInstance;
    [SerializeField] private int maxEnemiesPerInstance, minEnemiesPerInstance;

    // Update is called once per frame
    private void Start()
    {
        maxEnemiesPerInstance++;   
        StartCoroutine(InsEnemies());
    }
    
    IEnumerator InsEnemies()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(minEnemiesPerInstance, maxEnemiesPerInstance); i++)
            {
                Instantiate(enemies[Random.Range(0, enemies.Length)],
                    transform.position + new Vector3(Random.Range(-max, max), 0, 0),
                    new Quaternion(0,180,0,0));
            }

            yield return new WaitForSeconds(timeToInstance);
        }
    }
}