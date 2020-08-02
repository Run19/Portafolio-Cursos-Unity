using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float speedUp;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private LayerMask Ground;
    private float groundDistance = 1.45f;
    private Animator playerAnim;

    [SerializeField]
    private float playerEnergy { get; set; }
    public int playerCoins { get; set; }
    //AnimatorStates
    private const string IS_FALLING = "Falling";
    private const string IS_RUNING = "Runing";
    private const string IS_JUMPING = "Jumping";
    private const string IS_ALMOSTINGROUND = "AlmostInGround";


    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {

        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                this.transform.position = new Vector3(this.transform.position.x + speedUp * Time.deltaTime,
                                                      this.transform.position.y, this.transform.position.z);
                StartCoroutine("losingEnergy");
            }
            else
            {
                
                StopAllCoroutines();
                this.transform.position = new Vector3(this.transform.position.x + speed * Time.deltaTime,
                                                      this.transform.position.y, this.transform.position.z);
            }


            if (isOnGround())
            {
                playerAnim.SetBool(IS_RUNING, true);
                playerAnim.SetBool(IS_ALMOSTINGROUND, false);
                playerAnim.SetBool(IS_JUMPING, false);
                playerAnim.SetBool(IS_FALLING, false);
            }

            if (isOnGround() && Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            if (isOnGround() && Input.GetKeyDown(KeyCode.W))
            {
                useEnergy(15);
                playerRB.AddForce(Vector2.up * (jumpForce + 4.0f), ForceMode2D.Impulse);
            }

            if (playerRB.velocity.y < -0.1f)
            {
                playerAnim.SetBool(IS_RUNING, false);
                playerAnim.SetBool(IS_FALLING, true);
                if (AlmostOnGround())
                {
                    playerAnim.SetBool(IS_ALMOSTINGROUND, true);
                }
            }

            if (playerRB.velocity.y > 0.1f)
            {
                playerAnim.SetBool(IS_RUNING, false);
                playerAnim.SetBool(IS_JUMPING, true);
            }
        }

    }

    private bool isOnGround()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, groundDistance, Ground);
    }
    private bool AlmostOnGround()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, groundDistance + 2.0f, Ground);
    }

    IEnumerator losingEnergy()
    {
        while (true)
        {
            useEnergy();
            yield return new WaitForSeconds(0.1f);
        }
    }



    public void addCoins()
    {
        playerCoins++;
    }
    public int getCoins()
    {
        return playerCoins;
    }

    public float getPlayerEnergy()
    {
        return playerEnergy;
    }
    public void useEnergy(int energyValue = 0)
    {
        if (energyValue == 0)
            playerEnergy -= 0.1f;
        else
            playerEnergy -= energyValue;
    }
    public void winEnergy(int energyValue)
    {
        playerEnergy += energyValue;
    }
}
