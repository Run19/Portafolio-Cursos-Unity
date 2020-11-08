using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavScript : MonoBehaviour
{
    [SerializeField]
    private float velocity, damage, DamageForceX, DamageForceY;
    private Animator NavAnimator;
    private const string IS_ALIVE = "isAlive";
    private void Awake()
    {
        NavAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        NavAnimator.SetBool(IS_ALIVE, true);
    }
    void Update()
    {
        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            if (NavAnimator.GetBool("isAlive"))
            {
                this.transform.position = new Vector3(transform.position.x - (velocity * Time.deltaTime), transform.position.y, transform.position.z);
                if (this.transform.position.x < playerController.SI.transform.position.x - 30.0f)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                this.transform.position = new Vector3(transform.position.x - (velocity * Time.deltaTime), transform.position.y - Time.deltaTime, transform.position.z);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerController.SI.getInmuneState())
        {
            Rigidbody2D playerRb = playerController.SI.gameObject.GetComponent<Rigidbody2D>();
            playerController.SI.loseLife(damage);
            if (playerRb.velocity.x >= 0)
            {
                playerRb.velocity = Vector2.zero;
                playerRb.velocity = new Vector2(Vector2.right.x * -DamageForceX, Vector2.up.y * DamageForceY);
            }
            else
            {
                playerRb.velocity = Vector2.zero;
                playerRb.velocity = new Vector2(Vector2.left.x * -DamageForceX, Vector2.up.y * DamageForceY);
            }
        }
    }

    public void die()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine("dieC");
    }
    IEnumerator dieC()
    {
        NavAnimator.SetBool(IS_ALIVE, false);
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }
}
