using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLava : MonoBehaviour
{
    [SerializeField]
    private float lavaSpeed;
    private float lavaSpeedI;
    private float timeInGame;
    Vector3 initialPos;
    private void Awake()
    {
        lavaSpeedI = lavaSpeed;
        initialPos = this.transform.position;
    }
    void Update()
    {
        if (GameManager2Dplat.SI.currentGameState == GameState.InGame)
        {
            this.transform.position = new Vector3(this.transform.position.x + (lavaSpeed * Time.deltaTime), this.transform.position.y, transform.position.z);
            timeInGame += Time.deltaTime;
            if (timeInGame / 60 > 0.5 && lavaSpeed <= 5)
            {
                timeInGame = 0;
                lavaSpeedI++;
            }
        }
    }
    public void restartPos()
    {
        lavaSpeed = lavaSpeedI;
        this.transform.position = initialPos;
        timeInGame = 0;
    }
}
