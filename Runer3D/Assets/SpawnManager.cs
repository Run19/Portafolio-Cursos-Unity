using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField, Range(0.5f, 5.15f)] private float maxY;

    [SerializeField, Range(0, 10)]
    private int maxTimeBetweenSpawn, minTimeBetweenSpawn, maxObstaclesInEscene, objectsDestroyedByRound;

    private readonly Queue<GameObject> _currentObsInScene = new Queue<GameObject>();

    private void Start()
    {
        //StartCoroutine("InstanceObs");
        //LearningSection
        InvokeRepeating(nameof(InstanceObs), 0, Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn+1));
    }

    // IEnumerator InstanceObs()
    // {
    //     while (true)
    //     {
    //         var ranNum = Random.Range(0, obstacles.Count);
    //         var currentObs = Instantiate(obstacles[ranNum],
    //             new Vector3(transform.position.x, transform.position.y), obstacles[ranNum].transform.rotation);
    //         _currentObsInScene.Enqueue(currentObs);
    //         yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));
    //
    //         if (_currentObsInScene.Count > maxObstaclesInEscene)
    //         {
    //             for (var i = 0; i < objectsDestroyedByRound; i++)
    //             {
    //                 Destroy(_currentObsInScene.Dequeue().gameObject);
    //             }
    //         }
    //     }
    // }

    //LearnSection
    private void InstanceObs()
    {
        var ranNum = Random.Range(0, obstacles.Count);
        var currentObs = Instantiate(obstacles[ranNum],
            new Vector3(transform.position.x, transform.position.y), obstacles[ranNum].transform.rotation);
        _currentObsInScene.Enqueue(currentObs);
        if (_currentObsInScene.Count > maxObstaclesInEscene)
        {
            for (var i = 0; i < objectsDestroyedByRound; i++)
            {
                Destroy(_currentObsInScene.Dequeue().gameObject);
            }
        }
    }
    
}