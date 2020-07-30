using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum game
{
    Run2D,
    pong
}


public enum GameState
{
    mainMenu,
    InGame,
    GameOver
}

public class GameManager : MonoBehaviour
{

    public game currentGame;
    public GameState currentGameState;


    private int playerPoints;
    private int enemyPoints;
    public static GameManager SI;
    
    private void Awake()
    {
        if (SI == null)
        {
            SI = this;
        }
    }
    private void Start()
    {
        MainMenu();
    }


    public void StartGame()
    {
        playerPoints = 0;
        enemyPoints = 0;
        setGameState(GameState.InGame);
        CanvasManager.SI.setCanvasInGame();
        FindObjectOfType<Ball>().StartGame();
        FindObjectOfType<Score>().Point();
    }



    public void GameOver() {
        setGameState(GameState.GameOver);
        CanvasManager.SI.setCanvasInGameOver();
    }
    public void MainMenu()
    {
        setGameState(GameState.mainMenu);
        CanvasManager.SI.setCanvasInMenu();
    }
    #region getAndSett
    public int getPPoints() { return playerPoints; }
    public int getEPoints() { return enemyPoints; }

    public void pointE()
    {
        enemyPoints++;
        if (enemyPoints > 0)
        {
            Ball.SI.StopAllCoroutines();
             Invoke("GameOver",0.5f);
        }
    }
    public void pointP()
    {
        playerPoints++;
        if(playerPoints>0)
        {
            Ball.SI.StopAllCoroutines();
            Invoke("GameOver", 0.5f);
        }   
    }

    void setGameState(GameState newGameState) {
        currentGameState = newGameState;
    }
    #endregion
    public void backToStart()
    {
        SceneManager.LoadScene("Mainmenu");
    }



}
