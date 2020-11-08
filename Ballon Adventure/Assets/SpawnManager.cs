using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject money, bomb;
    private readonly List<GameObject> m_GameObjectsInScene = new List<GameObject>();
    private GameObject m_Player;

    private void Awake()
    {
        m_Player = m_Player == null ? GameObject.FindGameObjectWithTag("Player") : m_Player;
    }

    void Start()
    {
        InvokeRepeating(nameof(InsRandom), 0f, Random.Range(0.0f, 1.5f));
    }

    public void PlayerDie()
    {
        CancelInvoke();
        foreach (var obj in m_GameObjectsInScene.Where(obj => obj != null))
        {
            obj.GetComponent<MoveLeft>().StopMove();
        }
    }

    private void InsRandom()
    {
        if (Random.Range(0, 1.0f) < 0.7f)
        {
            var insObj = Random.Range(0, 1.0f) < 0.7f ? Ins(bomb) : Ins(money);
            m_GameObjectsInScene.Add(insObj);
        }


        GameObject Ins(GameObject obj)
        {
            return Instantiate(obj, new Vector3(transform.position.x, m_Player.transform.position.y),
                Quaternion.Euler(Vector3.zero));
        }
    }
}