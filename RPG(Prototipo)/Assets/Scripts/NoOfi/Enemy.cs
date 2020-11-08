///SCRIPT DE PRUEBA PARA EL ENEMIGO, NO ES EL OFICIAL


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum directions { 
left,
right,
up,
down
}

public class Enemy : MonoBehaviour
{
    Rigidbody2D enemyRb;
    Animator enemyAnim;
    float speed = 2;
    directions enemyMove=directions.right;
    float count = 0;


    //Boleano para definir si se esta moviendo
    bool isMoving;
    //Variables de animator
    const string Vertical = "Vertical";
    const string Horizontal = "Horizontal";
    const string isMovingAnim = "isMoving";
    
    
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        isMoving = true;
        
    }

    void Update()
    {

        if (isMoving)
        {
            
            switch (enemyMove)
            {
                case directions.right:
                    enemyAnim.SetFloat(Horizontal, 1.0f);
                    this.transform.position = new Vector3(this.transform.position.x + Time.deltaTime * speed
                                            , this.transform.position.y, 0);
                    count += Time.deltaTime;
                    if (count > 4)
                    {
                     
                        count = 0;
                       
                        isMoving = false;

                    }
                    break;


                case directions.down:
                    enemyAnim.SetFloat(Vertical, -1.0f);
                    this.transform.position = new Vector3(this.transform.position.x
                                     , this.transform.position.y - Time.deltaTime * speed, 0);
                    count += Time.deltaTime;
                    if (count > 4)
                    {
                       
                        count = 0;
                        
                        isMoving = false;
                    }
                    break;

                case directions.left:
                    enemyAnim.SetFloat(Horizontal, -1.0f);
                    this.transform.position = new Vector3(this.transform.position.x - Time.deltaTime * speed
                            , this.transform.position.y, 0);
                    count += Time.deltaTime;
                    if (count > 4)
                    {
                        
                        count = 0;
                       
                        isMoving = false;
                    }
                    break;

                case directions.up:
                    enemyAnim.SetFloat(Vertical, 1.0f);
                    this.transform.position = new Vector3(this.transform.position.x
                                    , this.transform.position.y + Time.deltaTime * speed, 0);
                    count += Time.deltaTime;
                    if (count > 4)
                    {
                        
                        count = 0;
                        
                        isMoving = false;
                    }
                    break;
            }
        }
        else {
            count += Time.deltaTime;
            if (count > 2) {

                switch (enemyMove)
                {
                    case directions.down:
                        enemyMove = directions.left;
                        enemyAnim.SetFloat(Vertical, 0f);
                        break;
                    case directions.up:
                        enemyMove = directions.right;
                        enemyAnim.SetFloat(Vertical, 0f);

                        break;
                    case directions.left:
                        enemyMove = directions.up;
                        enemyAnim.SetFloat(Horizontal, 1.0f);
                        break;
                    case directions.right:
                        enemyMove = directions.down;
                        enemyAnim.SetFloat(Horizontal, 0f);
                        break;

                }

                count = 0;
                isMoving = true;
            }

        }
        enemyAnim.SetBool(isMovingAnim, isMoving);
    }
}
