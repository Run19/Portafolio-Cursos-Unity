using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float velocity;
    private bool m_Moving = true;
    private static GameObject _player;

    private void Awake()
    {
        _player = _player == null ? GameObject.FindGameObjectWithTag("Player") : _player;
    }

    private void Update()
    {
        if (m_Moving)
        {
            transform.position = new Vector3(transform.position.x - velocity * Time.deltaTime, transform.position.y);
            if (transform.position.x < _player.transform.position.x - 10f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StopMove()
    {
        m_Moving = false;
    }
}