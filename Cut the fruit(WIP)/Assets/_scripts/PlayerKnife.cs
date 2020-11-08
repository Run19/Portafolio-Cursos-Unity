using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent, RequireComponent(typeof(BoxCollider), typeof(PlayerInput))]
public class PlayerKnife : MonoBehaviour
{
    private static PlayerKnife _singleInstance;

    private Knife _knife;
    private TrailRenderer _trail;
    private BoxCollider _collider;
    private Vector3 _mousePosition;
    private Camera _camera;
    private GameObject _playZone;

    private float _minX, _maxX, _minY, _maxY;

    private Renderer _playRender;


    private void Start()
    {
        SetBounds(_playRender);
        KnifeState(false);
    }


    private void Awake()
    {
        if (_singleInstance == null)
            _singleInstance = this;

        _camera = Camera.main;
        AssignComponents("Background");
        SetControl();
    }


    private void Update()
    {
        transform.position = _camera.ScreenToWorldPoint(new Vector3(Mouse.current.position.ReadValue().x,
            Mouse.current.position.ReadValue().y));

        ClampPos();
    }

    private void ClampPos()
    {
        var pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, _minX, _maxX), Mathf.Clamp(pos.y, _minY, _maxY), 0);
    }

    private void KnifeState(bool active = true)
    {
        _trail.enabled = active;
        _collider.enabled = active;
    }


    private void SetControl()
    {
        if (_knife == null)
            _knife = new Knife();


        _knife.Keyboard.Cut.performed += ctx => KnifeState();
        _knife.Keyboard.Cut.canceled += ctx => KnifeState(false);
    }


    private void AssignComponents(string lPlayZoneName)
    {
        _collider = GetComponent<BoxCollider>();
        _trail = GetComponent<TrailRenderer>();
        _playRender = GameObject.Find(lPlayZoneName).GetComponent<Renderer>();
    }

    private void SetBounds(Renderer lPlayerRenderer)
    {
        _minX = lPlayerRenderer.bounds.min.x;
        _maxX = lPlayerRenderer.bounds.max.x;
        _minY = lPlayerRenderer.bounds.min.y;
        _maxY = lPlayerRenderer.bounds.max.y;
    }

    private void OnEnable()
    {
        _knife.Enable();
    }

    private void OnDisable()
    {
        _knife.Disable();
    }
}