using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    mainMenu,
    InGame,
    GameOver
}

public class GameManager : MonoBehaviour
{
    private const int WINNER_SCORE = 5;

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



    public void GameOver()
    {
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
        if (enemyPoints >= WINNER_SCORE)
        {
            GameOver();
        }
    }
    public void pointP()
    {
        playerPoints++;
        if (playerPoints >= WINNER_SCORE)
        {
            GameOver();
        }
    }

    void setGameState(GameState newGameState)
    {
        currentGameState = newGameState;
    }
    #endregion
    public void backToStart()
    {
        SceneManager.LoadScene("Mainmenu");
    }



}
