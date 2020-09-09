using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class playerController : MonoBehaviour
{
    #region vars
    //Singleton
    public static playerController SI;
    //Audio Sources
    AudioSource playerAudioRep;
    [SerializeField]
    AudioClip dieClip, fallClip, jumpClip;
    //Variables del playerController
    [SerializeField]
    private float playerEnergy, playerLife, speed, speedUp, jumpForce, superJumpForce, fallSnap, jumpTime, enemyJumpBounce;
    private float iPlayerLife, iPlayerEnergy, iJumpTime;
    private Rigidbody2D playerRB;
    private float currentVelocity;
    private bool inmune, canMove;
    private Vector3 initialPositon;
    //Variables para la deteccion del suelo
    [SerializeField]
    private LayerMask Ground;
    [SerializeField]
    private float groundDistance = 1.45f;
    private int playerCoins;
    //Variables del animador
    private Animator playerAnim;
    //Estados del animator y axis
    private const string IS_FALLING = "Falling";
    private const string IS_RUNING = "Runing";
    private const string IS_JUMPING = "Jumping";
    private const string IS_ALMOSTINGROUND = "AlmostInGround";
    private const string AXIS_X = "Horizontal";
    private const string IS_ALIVE = "isAlive";
    #endregion
    #region monoloop
    private void Awake()
    {
        initialPositon = this.transform.position;
        SI = SI == null ? this : SI;
        iPlayerEnergy = playerEnergy;
        iPlayerLife = playerLife;
        iJumpTime = jumpTime;

    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAudioRep = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        playerRB.simulated = false;
    }
    private void FixedUpdate()
    {
        playerEnergy = playerEnergy < 0 ? 0 : playerEnergy;
        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            if (Input.GetKey(KeyCode.LeftShift) && playerEnergy > 0)
            {
                currentVelocity = speedUp;
                StartCoroutine("losingEnergy");
            }
            else
            {
                StopCoroutine("losingEnergy");
                currentVelocity = speed;
            }
            if (Math.Abs(Input.GetAxis(AXIS_X)) > 0 && canMove)
            {
                if (Input.GetAxis(AXIS_X) < 0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;

                playerRB.velocity = new Vector2(Input.GetAxis(AXIS_X) * currentVelocity, playerRB.velocity.y);
                playerAnim.SetBool(IS_RUNING, true);
            }
            else if (canMove)
            {
                playerRB.velocity = new Vector2(Vector2.zero.x, playerRB.velocity.y);
                StopCoroutine("losingEnergy");
                playerAnim.SetBool(IS_RUNING, false);
            }

            if (playerLife <= 0)
            {
                GameManager2Dplat.SI.gameOver();
                Debug.Log("TengañeSoyIo");
            }
            //Jump
            if (Input.GetKey(KeyCode.Space) && canMove && jumpTime > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y + (jumpForce * Time.deltaTime));
                jumpTime -= Time.deltaTime;
            }
            else if (!isOnGround())
            {
                jumpTime = 0;
                jump(fallSnap < 0 ? fallSnap : -fallSnap);
            }
            else if (isOnGround())
            {
                playerAnim.SetBool(IS_ALMOSTINGROUND, false);
                playerAnim.SetBool(IS_JUMPING, false);
                playerAnim.SetBool(IS_FALLING, false);
                jumpTime = iJumpTime;
                canMove = true;
            }


        }
    }


    private void Update()
    {

        if (isOnGround() && Input.GetKeyDown(KeyCode.W) && playerEnergy > 15 && canMove && jumpTime == iJumpTime)
        {
            jumpTime = 0;
            useEnergy(15);
            superJump(superJumpForce);
            playerAudioRep.PlayOneShot(jumpClip);
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
    #endregion
    #region PlyaerMethods
    private bool isOnGround()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, groundDistance, Ground);
    }
    private bool AlmostOnGround()
    {
        return Physics2D.Raycast(this.transform.position, Vector2.down, groundDistance + 2.0f, Ground);
    }

    private void jump(float force)
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y + (Vector2.up.y * force));
    }

    private void superJump(float force)
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, Vector2.up.y * force);

    }

    public void setInitialValues()
    {
        SoundControllerPlatform.SI.playMusic();
        jumpTime = 0;
        canMove = true;
        playerRB.velocity = Vector2.zero;
        inmune = false;
        playerAudioRep.PlayOneShot(fallClip);
        playerRB.simulated = true;
        playerCoins = 0;
        playerLife = iPlayerLife;
        playerEnergy = iPlayerEnergy;
        this.transform.position = initialPositon;
        playerAnim.SetBool(IS_ALIVE, true);
    }
    public void die()
    {
        playerAnim.SetBool(IS_ALIVE, false);
        playerAudioRep.PlayOneShot(dieClip);
    }
    #endregion
    #region Courutines

    IEnumerator losingEnergy()
    {
        while (true)
        {
            useEnergy();
            yield return new WaitForSeconds(1.1f);
        }
    }


    IEnumerator toggleColor()
    {
        canMove = false;
        inmune = true;
        for (int i = 0; i < 7; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(0.1f);
            if (i == 3)
            {
                canMove = true;
            }
        }
        inmune = false;

    }

    #endregion
    #region     Getter y setters
    public void winCoins(int coins = 0)
    {
        playerCoins += coins == 0 ? 1 : coins;
    }
    public int getCoins()
    {
        return playerCoins;
    }

    public float getPlayerEnergy()
    {
        return playerEnergy;
    }
    public void winEnergy(int energyValue)
    {
        playerEnergy = playerEnergy + energyValue > iPlayerEnergy ? playerEnergy : playerEnergy + energyValue;
    }
    public void useEnergy(int energyValue = 0)
    {
        playerEnergy -= energyValue == 0 ? 0.1f : energyValue;
    }

    public float getPlayerLife()
    {
        return playerLife;
    }
    public void loseLife(float lifeLost)
    {
        if (!inmune)
        {
            playerLife -= lifeLost;
            StartCoroutine("toggleColor");
        }
    }
    public void winLife(int value)
    {
        playerLife = playerLife + value > iPlayerLife ? playerLife : playerLife + value;
    }

    public bool getInmuneState()
    {
        return inmune;
    }

    public float getInitialPosition()
    {
        return initialPositon.x;
    }
    #endregion
    #region Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            if (collision.name == "Point")
            {
                if (playerRB.velocity.y <= 0)
                {
                    collision.GetComponentInParent<NavScript>().die();
                    superJump(enemyJumpBounce);
                    SoundControllerPlatform.SI.playSound("EnemyJump");
                    Destroy(collision);
                    GameManager2Dplat.SI.addScore(5);
                }
            }
            else if (collision.gameObject.CompareTag("Respawn"))
            {
                Destroy(collision);
                LvlGenerator.SI.destroyLastLvl();
                LvlGenerator.SI.addLvl();
            }
            else if (collision.gameObject.CompareTag("Finish") && playerAnim.GetBool(IS_ALIVE))
            {
                GameManager2Dplat.SI.gameOver();

            }
            else if (collision.CompareTag("poti"))
            {
                potionScript poti = collision.GetComponent<potionScript>();
                switch (poti.getPotiType())
                {
                    case potiType.energy:
                        {
                            winEnergy(poti.getPotiValue());
                            break;
                        }
                    case potiType.health:
                        {
                            winLife(poti.getPotiValue());
                            break;
                        }
                }
                Destroy(collision.gameObject);
            }
        }
    }
    #endregion
}
