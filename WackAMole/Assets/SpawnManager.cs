using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager singleInstance;


    [SerializeField] private List<GameObject> food = new List<GameObject>();
    [SerializeField] private List<GameObject> bad = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    private List<Vector3> _usedPoints = new List<Vector3>();

    [SerializeField, Range(0.2f, 2.0f)] private float timeBetweenObjects;
    [SerializeField, Range(2, 10)] private int minObjects, maxObjects;

    private float _currentTime;


    //GetCenterPoints
    private float _side;
    [SerializeField] private GameObject background;
    [SerializeField] private int squares;
    private float _size;

    private int _initialPosCount;


    private float _currentSkullProb;

    private void Awake()
    {
        if (singleInstance == null)
            singleInstance = this;


        _currentTime = 0;
        foreach (var origin in GetPoints())
            _points.Add(origin);

        _initialPosCount = _points.Count;
    }

    private void Update()
    {
        if (GameManager.singleInstance.GetCurrentGameState() != GameState.InGame) return;

        if (_initialPosCount != _points.Count) return;
        _currentTime += Time.deltaTime;
        if (!(_currentTime >= timeBetweenObjects)) return;
        _currentTime = 0;
        SpawnTargets();
    }


    private void SpawnTargets()
    {
        var items = Random.Range(minObjects, maxObjects);
        for (var i = 0; i < items; i++)
        {
            if (_points.Count <= 0)
                break;

            InsObj(food);
            if (Random.Range(0, 10) <= _currentSkullProb)
                InsObj(bad);
        }
    }


    private void InsObj(List<GameObject> objType)
    {
        var currentBad = Random.Range(0, objType.Count);
        var currentPosB = Random.Range(0, _points.Count);
        Instantiate(objType[currentBad], _points[currentPosB], objType[currentBad].transform.rotation);
        _usedPoints.Add(_points[currentPosB]);
        _points.Remove(_points[currentPosB]);
    }


    public void RestorePositionList(Vector3 point)
    {
        _points.Add(point);
        _usedPoints.Remove(point);
    }


    private void OnDrawGizmos()
    {
        foreach (var origin in GetPoints())
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(origin, new Vector3(_side, _side, 0));
        }
    }

    private IEnumerable<Vector3> GetPoints()
    {
        var points = new List<Vector3>();
        var render = background.GetComponent<Renderer>();
        _size = render.bounds.size.x;
        _side = _size / squares;

        //Set initial origin
        var origin = new Vector3(render.bounds.min.x + _side / 2, render.bounds.max.y - _side / 2);

        for (var i = 0; i < squares; i++)
        {
            if (i > 0)
                //Reset X push Y
                origin = new Vector3(render.bounds.min.x + _side / 2, origin.y - _side);

            for (var j = 0; j < squares; j++)
            {
                if (j > 0)
                    //push X
                    origin = new Vector3(origin.x + _side, origin.y);

                points.Add(origin);
            }
        }

        return points;
    }


    public void SetSkullProb(float skullProb)
    {
        _currentSkullProb = skullProb;
    }
}