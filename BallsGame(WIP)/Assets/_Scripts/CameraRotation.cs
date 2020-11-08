using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private float _horizontalInput;
    private Controller _controller;

    private void Awake()
    {
        _controller = new Controller();
        _controller.Keyboard.CamRotation.performed += ctx => _horizontalInput = ctx.ReadValue<float>();
        _controller.Keyboard.CamRotation.canceled += ctx => _horizontalInput = 0;
    }

    private void Update()
    {
        if (_horizontalInput == 0) return;
        transform.Rotate(Vector3.up, _horizontalInput * rotationSpeed * Time.deltaTime);
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