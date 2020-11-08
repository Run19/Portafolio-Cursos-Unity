using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[DisallowMultipleComponent]
public class SpawnManager : MonoBehaviour
{
    public List<GameObject> food = new List<GameObject>();
    public List<GameObject> powerUps = new List<GameObject>();
    public List<GameObject> bad = new List<GameObject>();
    [SerializeField, Range(0, 2)] private float minTimeXItem, maxTimeXItem;
    [SerializeField, Range(0.2f, 2)] private float minTimeSleep, maxTimeSleep;
    [SerializeField, Range(0, 10)] private float probBomb, probPowerUp;
    [SerializeField, Range(2, 20)] private int minItemsIns, maxItemsIns;
    [SerializeField, Range(0, 0.5f)] private float timeScalerDiff;
    private Coroutine _cInsObj;
    private BoxCollider _collider;
    private float _minX, _maxX;


    private void Awake()
    {
        SetBounds();
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (GameManager.SingleInstance.GetCurrGameState() != GameState.InGame) return;

        if (_cInsObj != null) return;
        _cInsObj = StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        var objsToIns = Random.Range(minItemsIns, maxItemsIns);

        for (var i = 0; i < objsToIns; i++)
        {
            if (GameManager.SingleInstance.GetCurrGameState() != GameState.InGame)
            {
                _cInsObj = null;
                break;
            }

            InsObjs();
            yield return new WaitForSeconds(Random.Range(minTimeXItem, maxTimeXItem));
        }

        Time.timeScale += timeScalerDiff;
        yield return new WaitForSeconds(Random.Range(minTimeSleep, maxTimeSleep));
        _cInsObj = null;
    }


    private void InsObjs()
    {
        InsFood(food);

        if (ProbObj(probPowerUp))
            InsFood(powerUps);

        if (ProbObj(probBomb))
            InsFood(bad);
    }


    private bool ProbObj(float prob)
    {
        return Random.Range(0, 10) <= prob;
    }

    private void InsFood(List<GameObject> obj)
    {
        Instantiate(obj[Random.Range(0, obj.Count)],
            new Vector3(Random.Range(_minX, _maxX), 0, 0),
            Quaternion.Euler(Vector3.zero));
    }

    private void SetBounds()
    {
        _collider = GetComponent<BoxCollider>();
        _minX = _collider.bounds.min.x;
        _maxX = _collider.bounds.max.x;
    }
}