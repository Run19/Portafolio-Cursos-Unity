using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball SI;
    Rigidbody2D ballRb;
    [SerializeField]
    float Velocity;
    Vector3 initialpos;

    private void Awake()
    {

        if (SI == null)
        {
            SI = this;
        }
        ballRb = GetComponent<Rigidbody2D>();
        initialpos = this.transform.position;
    }


    public void StartGame()
    {
        this.transform.position = initialpos;
        StartCoroutine("point");
    }


    void addVelocity()
    {
        ballRb.velocity = new Vector2(Velocity * (UnityEngine.Random.value > 0.5f ? 1.0f : -1.0f), 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.SI.currentGameState == GameState.InGame)
        {
            if (collision.tag == "enemyPoint")
            {
                GameManager.SI.pointE();
                StartCoroutine("point");
            }
            if (collision.tag == "playerPoint")
            {
                GameManager.SI.pointP();
                StartCoroutine("point");
            }


            if (collision.gameObject.CompareTag("Bounce"))
            {
                ballRb.velocity = collision.gameObject.GetComponent<Bounce>().bouncenes.normalized * Velocity;
            }
        }
        else
        {
            ballRb.velocity = Vector2.zero;
        }

    }
    IEnumerator point()
    {
        StopCoroutine("velocityOnTime");
        ballRb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.2f);
        FindObjectOfType<Score>().Point();
        this.transform.position = initialpos;
        yield return new WaitForSeconds(0.3f);
        restartPos();
        yield return new WaitForSeconds(1.0f);
        addVelocity();
        StartCoroutine("velocityOnTime");
    }
    IEnumerator velocityOnTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            ballRb.velocity = new Vector2(ballRb.velocity.x * 1.5f, ballRb.velocity.y);
        }

    }


    void restartPos()
    {
        FindObjectOfType<paddleMove>().transform.position = new Vector3(FindObjectOfType<paddleMove>().transform.position.x, 0);
        FindObjectOfType<Enemy>().transform.position = new Vector3(FindObjectOfType<Enemy>().transform.position.x, 0);
    }

}


