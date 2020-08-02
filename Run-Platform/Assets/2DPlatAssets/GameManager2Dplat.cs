using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class GameManager2Dplat : MonoBehaviour
{
    public static GameManager2Dplat SI;
    public GameState currentGameState;
    private Vector3 initialPos;
    private GameObject player;
    private float points = 0;
    private void Awake()
    {
        if (SI == null) {
            SI = this;
        }
    }
    private void Start()
    {
        initialPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        player = GameObject.FindGameObjectWithTag("Player");

    }
    private void Update()
    {
        if (currentGameState == GameState.InGame)
        {
            points += Time.deltaTime;
        }
    }
    #region ChangeGameState

    public void gameOver()
    {
        setGamaState(GameState.GameOver);
        player.GetComponent<Rigidbody2D>().simulated = false;
    }
    public void mainMenu()
    {
        setGamaState(GameState.mainMenu);
        player.GetComponent<Rigidbody2D>().simulated = false;
    }

    public void startGame()
    {
        points = 0;
        player.transform.position = initialPos;
        setGamaState(GameState.InGame);
        player.GetComponent<Rigidbody2D>().simulated = true;
    }
    public void setGamaState(GameState newGameState)
    {
        currentGameState = newGameState;
    }
    #endregion
    //Getter y setter

}
