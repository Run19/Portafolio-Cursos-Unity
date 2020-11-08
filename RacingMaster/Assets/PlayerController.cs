using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0)] private float velocity, rotationAngle;
    private Rigidbody2D _playerRb;
    private bool _canRotate;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _playerRb.velocity = Input.GetAxis("Horizontal") == 0
            ? Vector2.zero
            : Vector2.right * (Input.GetAxis("Horizontal") * velocity);
        _playerRb.rotation = Input.GetAxis("Horizontal") == 0
            ? 0
            : rotationAngle * -Input.GetAxis("Horizontal");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;
        SoundManager.SI.playGameOverSound();
        GameManager.SI.gameOver();
    }
}