using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Enemies = new List<GameObject>();
    [SerializeField]
    GameObject Target;
    [SerializeField]
    private int[] timing = new int[3];
    private float currentTimeMax, currentTime;


    private void Start()
    {
        currentTimeMax = timing[Random.Range(0, timing.Length)];
    }
    public void generateEnemies()
    {
        Instantiate(Enemies[Random.Range(0, Enemies.Count)],
            new Vector3(transform.position.x, Target.transform.position.y, 0), Quaternion.Euler(Vector3.zero));
    }
    void Update()
    {
        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            if (currentTime % 60 > currentTimeMax)
            {
                currentTime = 0;
                currentTimeMax = timing[Random.Range(0, timing.Length)];
                generateEnemies();
            }
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }
    }
    public void DestroyAllEnemies()
    {
        if (FindObjectsOfType<NavScript>().Length > 0)
        {
            foreach (NavScript currentEnemy in FindObjectsOfType<NavScript>())
            {
                Destroy(currentEnemy.gameObject);
            }
        }
    }
}
