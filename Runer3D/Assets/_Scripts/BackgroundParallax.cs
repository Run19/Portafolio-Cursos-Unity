using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField, Range(-200, 200)] private float velocity;
    private SpriteRenderer _spriteRenderer;
    private float _spriteSizeX;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteSizeX = _spriteRenderer.size.x;
    }


    private void Update()
    {
        transform.Translate(velocity*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var currentPos=transform.position;
            transform.position=new Vector3(currentPos.x+(_spriteSizeX*1.38f),currentPos.y,currentPos.z);
        }
    }
}