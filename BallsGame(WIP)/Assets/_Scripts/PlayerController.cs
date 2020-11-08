using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce;
    private Controller _controller;
    private float _direction;
    private Rigidbody _rigidbody;


    //Obtenemos el punto por el cual nos vamos a orientar para movernos(Cordenadas relativas)
    private GameObject _origin;

    private void Awake()
    {
        _origin = GameObject.Find("Origin");
        _controller = new Controller();
        _controller.Keyboard.MoveForward.performed += ctx => _direction = ctx.ReadValue<float>();
        _controller.Keyboard.MoveForward.canceled += ctx => _direction = 0;

        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_direction == 0)
        {
            return;
        }

        _rigidbody.AddForce(_origin.transform.forward * (moveForce * _direction), ForceMode.Acceleration);
    }

    private void OnEnable()
    {
        _controller.Enable();
    }

    private void OnDisable()
    {
        _controller.Disable();
    }
}