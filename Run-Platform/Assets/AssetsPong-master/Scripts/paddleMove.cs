using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

enum playMode
{
    mouse,
    buttons
}

public class paddleMove : MonoBehaviour
{

    public static paddleMove SI;
    float speed = 12.0f;
    float currentAxis;
    [SerializeField]
    playMode curentMode = 0;
    Rigidbody2D body;
    private void Awake()
    {
        if (SI == null)
        {
            SI = this;
        }

        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

        if (curentMode == 0)
        {

            Vector3 paddlePos = (Camera.main.ScreenToWorldPoint(Input.mousePosition));

            transform.position = new Vector3(transform.position.x,
                                               Mathf.Clamp(paddlePos.y, -4.09f, 4.09f),
                                                transform.position.z);
        }
        else
        {

            currentAxis = Input.GetAxis("Vertical");
            this.transform.position = new Vector3(this.transform.position.x,
                                                 Mathf.Clamp(this.transform.position.y +
                                                            (speed * Time.deltaTime * currentAxis)
                                                            , -4.09f, 4.09f), 0f);
        }
    }

    public void changeGameMode()
    {
        curentMode = curentMode == playMode.buttons ? playMode.mouse : playMode.buttons;
    }
}
