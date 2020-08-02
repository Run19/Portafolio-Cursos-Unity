using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball SI;
    Rigidbody2D ballRb;
    [SerializeField]
    float Velocity;
    Vector3 initialpos;
    public GameObject GoText;
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
                SoundManager.SI.enemySound();
            }
            if (collision.tag == "playerPoint")
            {
                GameManager.SI.pointP();
                StartCoroutine("point");
                SoundManager.SI.playerSound();
            }


            if (collision.gameObject.CompareTag("Bounce"))
            {
                ballRb.velocity = collision.gameObject.GetComponent<Bounce>().bouncenes.normalized * Velocity;
                RestoreColor();
            }
        }
        else
        {
            RestoreColor();
            ballRb.velocity = Vector2.zero;
        }

    }
    IEnumerator point()
    {
        StopCoroutine("velocityOnTime");
        RestoreColor();
        ballRb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.2f);
        this.transform.position = initialpos;
        yield return new WaitForSeconds(0.1f);
        restartPos();
        if (GameManager.SI.currentGameState == GameState.InGame)
        {
            Instantiate(GoText,new Vector3(0f, 0f, 0f), quaternion.Euler(Vector3.zero));
            FindObjectOfType<Score>().Point();
            yield return new WaitForSeconds(1.0f);
            addVelocity();
            StartCoroutine("velocityOnTime");
        }
    }
    IEnumerator velocityOnTime()
    {
        while (GameManager.SI.currentGameState == GameState.InGame)
        {
            yield return new WaitForSeconds(5.0f);
            onFire();
            ballRb.velocity = new Vector2(ballRb.velocity.x * 1.5f, ballRb.velocity.y*1.2f);
        }

    }

    void restartPos()
    {
        if (paddleMove.SI.curentMode == playMode.buttons)
        {
            FindObjectOfType<paddleMove>().transform.position = new Vector3(FindObjectOfType<paddleMove>().transform.position.x, 0);
            FindObjectOfType<Enemy>().transform.position = new Vector3(FindObjectOfType<Enemy>().transform.position.x, 0);
        }
        else
        {
            FindObjectOfType<Enemy>().transform.position = new Vector3(FindObjectOfType<Enemy>().transform.position.x, 0);
        }
    }

    void onFire()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
    }
    void RestoreColor()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

}


