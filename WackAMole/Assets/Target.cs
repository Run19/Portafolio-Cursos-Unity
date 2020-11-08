using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField, Range(-30, 30)] private float points;
    [SerializeField] private ParticleSystem particleSystem;

    private MeshRenderer _meshRenderer;
    private Collider _collider;

    private static float _timeToDestroy = 1;

    private float _currentTime;

    private bool _destroying;


    private void Awake()
    {
        _destroying = false;
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentTime = 0;
    }

    private void Update()
    {
        if (GameManager.singleInstance.GetCurrentGameState() != GameState.InGame)
        {
            if (!_destroying)
                DestroySelf(false);
            return;
        }

        _currentTime += Time.deltaTime;

        if (_currentTime >= _timeToDestroy && !_destroying)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        DestroySelf(true);
    }


    private void DestroySelf(bool clicked)
    {
        _destroying = true;
        _meshRenderer.enabled = false;
        _collider.enabled = false;
        particleSystem.Play();
        Destroy(gameObject, 1.5f);

        if (!clicked) return;

        GameManager.singleInstance.ChangePoints(points);
        if (points < 0)
            GameManager.singleInstance.LostTime(5);
    }

    private void OnDestroy()
    {
        SpawnManager.singleInstance.RestorePositionList(transform.position);
    }


    public static void ChangeTime(float time)
    {
        _timeToDestroy = time;
    }
}