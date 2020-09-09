using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private BallonMove m_Controller;
    private Rigidbody m_PlayerRb;
    private bool m_Flying, m_IsAlive;
    private MeshRenderer m_PlayerMesh;
    public UnityEvent onDie;
    [SerializeField, Range(0, 3)] private float gravityMultiplier;
    [SerializeField, Range(0, 100)] private float flyForce, velocity;
    [SerializeField] private ParticleSystem winCoin, dieEffect;


    private void Awake()
    {
        m_IsAlive = true;
        m_PlayerMesh = GetComponent<MeshRenderer>();
        Physics.gravity = new Vector3(0, -9.8f * gravityMultiplier, 0);
        m_Controller = new BallonMove();
        m_Controller.Keybpard.Fly.performed += ctx => m_Flying = true;
        m_Controller.Keybpard.Fly.canceled += ctx => m_Flying = false;
        m_Controller.Keybpard.Reestart.performed += ctx => LoadScene();
        m_PlayerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_Flying && m_IsAlive)
            Fly();
    }

    private void LoadScene()
    {
        if (!m_IsAlive)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Fly()
    {
        m_PlayerRb.AddForce(flyForce * Vector3.up, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bomb")) return;
        onDie.Invoke();
        m_IsAlive = false;
        dieEffect.Play();
        m_PlayerMesh.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            winCoin.Play();
            Destroy(other.gameObject);
        }
    }

    private void OnEnable()
    {
        m_Controller.Enable();
    }

    private void OnDisable()
    {
        m_Controller.Disable();
    }
}