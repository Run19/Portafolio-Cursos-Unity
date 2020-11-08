using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController ShIn;
    private Animator _playerAnimator;
    private Rigidbody _playerRb;
    private Controller _player;
    private AudioSource _audioReproductor;
    private bool _isOnGround;
    private bool _isAlive;
    private float _life;

    [SerializeField, Range(-30, -29)] private float maxGravity;
    [SerializeField, Range(0, 3)] private float gravity;
    [SerializeField, Range(0, 20)] private float jumpForce, speed;
    [SerializeField, Range(0, 150)] private float initialLife;
    [SerializeField] private ParticleSystem walkParticles, hitParticles;

    [SerializeField] private AudioClip hitSound, dieSound, jumpSound;

    //Animator States 
    private static readonly int AnimPropJump = Animator.StringToHash("Jump_trig");
    private static readonly int AnimPropRun = Animator.StringToHash("Speed_f");
    private static readonly int AnimPropDeath = Animator.StringToHash("Death_b");
    private static readonly int AnimPropDeathType = Animator.StringToHash("DeathType_int");

    private void Awake()
    {
        _audioReproductor = GetComponent<AudioSource>();
        ShIn = ShIn == null ? this : ShIn;
        Physics.gravity *= Physics.gravity.y >= maxGravity ? gravity : 1;
        _playerAnimator = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
        _player = new Controller();
        _player.Keyboard.Jump.performed += ctx => Jump();
        _player.Keyboard.ReestartGame.performed += ctx => RestartGame();
        SetInitialValues();
    }

    private void SetInitialValues()
    {
        _isOnGround = true;
        _isAlive = true;
        walkParticles.Play();
        _playerAnimator.SetBool(AnimPropDeath, false);
        _playerAnimator.SetFloat(AnimPropRun, 1.0f);
        Life = initialLife;
    }

    private void FixedUpdate()
    {
        if (_isAlive)
            _playerRb.AddForce(Vector2.right * (speed * _playerRb.mass), ForceMode.Acceleration);
    }

    private void RestartGame()
    {
        if (!_isAlive)
        {
            StartCoroutine(ApplyCrossFade());
        }
    }

    private void Jump()
    {
        if (_isOnGround)
        {
            _audioReproductor.PlayOneShot(jumpSound);
            walkParticles.Stop();
            _isOnGround = false;
            _playerAnimator.ResetTrigger(AnimPropJump);
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            _playerAnimator.SetTrigger(AnimPropJump);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            if (!walkParticles.isPlaying)
                walkParticles.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            hitParticles.Play();
            _life -= 20;
            other.rigidbody.AddForce(new Vector3(0, 0, Random.Range(0, 1.0f) > 0.5f ? 30.0f : -30.0f),
                ForceMode.VelocityChange);

            if (_life <= 0)
                Die();
            else
                _audioReproductor.PlayOneShot(hitSound);
        }
    }


    IEnumerator ApplyCrossFade()
    {
        FindObjectOfType<FadeMusic>().EndGame();
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene(0);
    }

    private void Die()
    {
        _audioReproductor.PlayOneShot(dieSound);
        walkParticles.Stop();
        _isAlive = false;
        _playerAnimator.SetBool(AnimPropDeath, true);
        _playerAnimator.SetInteger(AnimPropDeathType, 1);
    }


    #region GETTERS Y SETTERS

    public float Life
    {
        set => _life = value >= 0 ? value : _life;
        get => _life;
    }

    #endregion

    private void OnEnable()
    {
        _player.Enable();
    }

    private void OnDisable()
    {
        _player.Disable();
    }
}