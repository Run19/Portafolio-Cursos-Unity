using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Jobs;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    //redundant variables
    private Rigidbody _playerRigidBody;

    private CarController _car;
    private Vector2 _move;

    [SerializeField, Range(0, 50), Tooltip("Current Car Velocity")]
    private float velocity;


    private void Awake()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        _car = new CarController();

        _car.CarMove.Move.performed += ctx => _move = ctx.ReadValue<Vector2>();
        _car.CarMove.Move.canceled += ctx => _move = Vector2.zero;
    }

    private void Update()
    {
        if (_move != Vector2.zero)
        {
            transform.Translate(_move.x * Time.deltaTime * velocity, 0, _move.y * Time.deltaTime * velocity,
                Space.World);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.13f, 8.75f),
                Mathf.Clamp(transform.position.y, 0, 2), Mathf.Clamp(transform.position.z, -10.69f, 192.48f));

            transform.Rotate(Vector3.up * _move.x);
        }
    }


    private void OnEnable()
    {
        _car.CarMove.Enable();
    }

    private void OnDisable()
    {
        _car.CarMove.Disable();
    }
}