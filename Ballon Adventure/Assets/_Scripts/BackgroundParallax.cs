using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField, Range(-200, 200)] private float velocity;
    private SpriteRenderer m_SpriteRenderer;
    private float m_SpriteSizeX;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteSizeX = m_SpriteRenderer.size.x;
    }


    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var currentPos = transform.position;
            transform.position = new Vector3(currentPos.x + (m_SpriteSizeX), currentPos.y, currentPos.z);
        }
    }

    public void StopMoving()
    {
        velocity = 0;
    }
}