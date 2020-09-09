using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Variables del pj
    public float speed = 550.0f;
    private float currentSpeed;
    public Vector2 lastMovement = Vector2.zero;//Nos ayudara a darle la dirección final del personaje
    private bool isMovingOn; //Creamos este bool para darle dimamismo al movmiento 
    private bool isAtacking;
    public static bool playerCreated;//Confirmar que el plauyer se encuentra creado y no crear alguno mas
    public string nextScene = "PrincipalScene";
    //Variables del ataque
    [SerializeField]
    private float atackTime;
    private float atackTimeCounter;
    //Valores del animator
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string isMoving="isMoving";
    private const string lastVertical= "lastVertical";
    private const string lastHorizontal = "lastHorizontal";
    private const string isAtackingS = "isAtacking";
    private Animator anim;
    private Rigidbody2D pjBody;
    void Start()
    {
        atackTimeCounter = 0;
        anim = GetComponent<Animator>();
        pjBody = GetComponent<Rigidbody2D>();
        if (!playerCreated)
        {
            playerCreated = true;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(gameObject);
        }

        lastMovement = new Vector2(0, -1);
    }
    void Update()
    {
        //Ataque del jugador
        if (Input.GetMouseButtonDown(0)) {

            if (atackTimeCounter <= 0) {
                isAtacking = true;
                atackTimeCounter = atackTime;
                pjBody.velocity = Vector2.zero;
                anim.SetBool(isAtackingS, isAtacking);
            }
        }

        if (isAtacking)
        {
            atackTimeCounter -= Time.deltaTime;
            if (atackTimeCounter < 0)
            {
                //StopAtacking
                isAtacking = false;
                anim.SetBool(isAtackingS, isAtacking);    
            }

        }
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f ||
            Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
        {
            isMovingOn = true;
            lastMovement = new Vector2(Input.GetAxisRaw(horizontal),
                                  Input.GetAxisRaw(vertical));


            pjBody.velocity = lastMovement.normalized * speed * Time.deltaTime;
         }
        else {
                isMovingOn = false;
            pjBody.velocity = Vector2.zero;
        }
        //Floats Del Animator
        anim.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        anim.SetFloat(vertical, Input.GetAxisRaw(vertical));
        anim.SetFloat(lastVertical, lastMovement.y);
        anim.SetFloat(lastHorizontal, lastMovement.x);
        anim.SetBool(isMoving, isMovingOn);
    }
}