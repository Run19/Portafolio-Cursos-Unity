using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public gameState currentGameState;
    float currentTime;
    float currentScore;
    public static GameManager SI;
    private void Awake()
    {
        SI = SI == null ? this : SI;
    }
    void Start()
    {
        MainMenu();
    }

    void Update() 
    {
        if (currentGameState == gameState.inGame)
        {
            currentTime += Time.deltaTime;
            currentScore += Time.deltaTime * StreetMove.speed;
        }
    }


    //Metodo ejecutado al iniciar una partida
    public void startGame()
    {
        CanvasManager.SI.setCanvasInGame();
        StreetMove.setInitGameValues();
        Invoke("setGameStateInGame", 3.2f);
        currentTime = 0;
        currentScore = 0;
        SoundManager.SI.playMusicInGame();

    }
    //Metodo llamada cuando el jugador pierde
    public void gameOver()
    {
        CanvasManager.SI.setCanvasGameOver();
        setMaxScore();
        currentGameState = gameState.GameOver;
    }
    
    //Metodo llamado al regresar al menu inicial
    public void MainMenu()
    {
        CanvasManager.SI.setCanvasMainMenu();
        currentGameState = gameState.mainMenu;
        SoundManager.SI.playMusicInGame();
    }


    //Metodo llamada para comprobar si hay un nuevo record
    void setMaxScore()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            if (currentScore > PlayerPrefs.GetFloat("MaxScore"))
                PlayerPrefs.SetFloat("MaxScore", currentScore);
        }
        else PlayerPrefs.SetFloat("MaxScore", currentScore);
    }
    
    //Invocamos a la variable tardia para la cuenta regresiva
    private void setGameStateInGame()
    {
        currentGameState = gameState.inGame;
    }
    
    public float getCurrentTime()
    {
        return currentTime;
    }
    public float getCurrentScore()
    {
        return currentScore;
    }
}
