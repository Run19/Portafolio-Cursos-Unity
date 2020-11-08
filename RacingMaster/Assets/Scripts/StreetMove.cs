using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class StreetMove : MonoBehaviour
{
    public static float speed;
    private static int scoreMultAux;

    private void FixedUpdate()
    {
        if (GameManager.SI.currentGameState == gameState.inGame)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime, this.transform.position.z);
        }
        if (Mathf.Ceil(GameManager.SI.getCurrentTime()) == scoreMultAux)
        {
            speed++;
            scoreMultAux += 10;
        }
    }


    public static void setInitGameValues()
    {
        speed = 5;
        scoreMultAux = 10;
    }
}
