using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour 
{
    public float enemySpeed = 1;
    private Rigidbody2D enemyRb;
    private bool isMoving;

    public float timeBetwenSteps;
    private float timeBewtenStepsCount;
    
    public float timeToMakeStep;
    private float timeToMakeStepCounter;

    public Vector2 directionToMakeStep;

    private Animator enemyAnim;


    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string isMovingAnim = "isMoving";


    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();


        timeBewtenStepsCount = timeBetwenSteps*Random.Range(0.5f,1.5f);
        timeToMakeStepCounter = timeBetwenSteps * Random.Range(0.5f, 1.5f);
    }


    void Update()
    {
        
        if (isMoving) {
            timeToMakeStepCounter -= Time.deltaTime;
            enemyRb.velocity = directionToMakeStep;
            if (timeToMakeStepCounter < 0) {
                isMoving = false;
                timeBewtenStepsCount = timeBetwenSteps;
                enemyRb.velocity = Vector2.zero;
            }
        }



        else{
            timeBewtenStepsCount -= Time.deltaTime;
            if (timeBewtenStepsCount < 0) {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMakeStep = new Vector2(Random.Range(-1, 2)
                                                 ,Random.Range(-1, 2))*enemySpeed;
            }
        }


        enemyAnim.SetFloat(Horizontal, directionToMakeStep.x);
        enemyAnim.SetFloat(Vertical, directionToMakeStep.y);
        enemyAnim.SetBool(isMovingAnim, isMoving);

    }
}
