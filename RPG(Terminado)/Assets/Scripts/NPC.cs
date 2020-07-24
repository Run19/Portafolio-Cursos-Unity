using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed = 1.5f;
    private Rigidbody2D npcRb;

    public bool isWalking;
    
    public float walkTime = 1.5f;
    private float walkCounter;

    public float waitTime = 3.0f;
    private float waitTimeCounter;

    int currentDirection;


    public BoxCollider2D npcZone;
    
    private Vector2[] walkingDirection = {
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0,-1)
    };
    
    
    void Start()
    {
        npcRb = GetComponent<Rigidbody2D>();
        waitTimeCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {

     


        if (isWalking)
        {
            if (npcZone != null) {
                if (this.transform.position.x < npcZone.bounds.min.x ||
                    this.transform.position.x > npcZone.bounds.max.x ||
                    this.transform.position.y > npcZone.bounds.min.y ||
                    this.transform.position.y < npcZone.bounds.max.y
                    ) {
                    stopWalking();
                    return;
                }
                
            }

            npcRb.velocity = walkingDirection[currentDirection] * speed;
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0) {
                stopWalking();
            }
        }
        else {
            npcRb.velocity = Vector2.zero;
            waitTimeCounter -= Time.deltaTime;
            if (waitTimeCounter < 0) {
                startWalking();
            }
        }


   
    }




    void startWalking() {
        isWalking = true;
        currentDirection= Random.Range(0, 4);
        walkCounter = walkTime;

    }

    void stopWalking() {
        isWalking = false;
        waitTimeCounter = waitTime;
        npcRb.velocity = Vector2.zero;

    }





}
