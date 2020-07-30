using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum enemyDif{
    Noob,
    Normal,
    Hard,   
    insane
}


public class Enemy : MonoBehaviour
{
    enemyDif enemyDiff;
    public static Enemy SI;
    private float speed;
    [SerializeField]
    GameObject ball;
    Vector3 destiny;
    Rigidbody2D ballRb;
    float extraHit;
    private void Awake()
    {
        ballRb = ball.GetComponent<Rigidbody2D>();
        if (SI == null)
        {
            SI = this;
        }
    }
    void Update()
    {
        if (paddleMove.SI.transform.position.y > 0)
        {
            extraHit = 0.5f;
        }
        else
        {
            extraHit = -0.5f;
        }

        if (ballRb.velocity.x > 0 && ball.transform.position.x > -3.0f)
        {
            destiny = new Vector3(ball.transform.position.x, ball.transform.position.y + extraHit);
        }
        else 
        {
            destiny = new Vector3(this.transform.position.x, 0f);
        }
        goDestiny(destiny);
    }

    void goDestiny(Vector3 destiny)
    {
        if (destiny.y > this.transform.position.y)
        {
            this.transform.position = new Vector3(this.transform.position.x,
                                                 Mathf.Clamp(this.transform.position.y +
                                                            (speed * Time.deltaTime)
                                                            , -4.09f, 4.09f));
        }
        else if (destiny.y < this.transform.position.y)
        {
            this.transform.position = new Vector3(this.transform.position.x,
                                                 Mathf.Clamp(this.transform.position.y -
                                                            (speed * Time.deltaTime)
                                                            , -4.09f, 4.09f));
        }
    }



    public void noob()
    {
        speed = 4;
        enemyDiff = enemyDif.Noob;
    }

    public void easy()
    {
        
        speed = 5;
        enemyDiff = enemyDif.Normal;
    }

    public void Hard()
    {
        speed = 6;
        enemyDiff = enemyDif.Hard;
    }

    public void Insane()
    {
        speed = 7;
        enemyDiff = enemyDif.insane;
    }


    public enemyDif getEnemyDif() {
        return enemyDiff;
    }
}
