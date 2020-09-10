using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
//Controla los estados del juego y las puntuaciones
public class GameManager2Dplat : MonoBehaviour
{
    public static GameManager2Dplat SI;
    public GameState currentGameState;
    private GameObject player;
    private playerController playerControllerI;
    private float Score = 0;
    private float playerMaxPos;
    private bool newMaxScore;
    private void Awake()
    {
        if (SI == null)
        {
            SI = this;
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        mainMenu();
        playerControllerI = player.GetComponent<playerController>();
        playerMaxPos = player.transform.position.x;
    }
    private void Update()
    {
        if (currentGameState == GameState.InGame)
        {
            if (player.transform.position.x > playerMaxPos)
            {
                addScore(Time.deltaTime * 10);
                Score = (float)Math.Round(Score, 1);
                playerMaxPos = player.transform.position.x;
            }
        }
    }
    #region ChangeGameState
    public void gameOver()
    {
        SoundControllerPlatform.SI.playMusic();
        StartCoroutine("gameOverC");
    }
    public void mainMenu()
    {
        SoundControllerPlatform.SI.playMusic();
        SetGameState(GameState.mainMenu);
        player.GetComponent<Rigidbody2D>().simulated = false;
        CanvasManager.SI.setCanvasInMenu();
        FindObjectOfType<EnemyGenerator>().DestroyAllEnemies();
    }

    public void startGame()
    {
        FindObjectOfType<correctCineMachine>().restartPos();
        FindObjectOfType<ParallaxBackground>().setInitialPosition();
        FindObjectOfType<moveLava>().restartPos();
        LvlGenerator.SI.generateInitialLvl();
        newMaxScore = false;
        CanvasManager.SI.setCanvasInGame();
        Score = 0;
        SetGameState(GameState.InGame);
        playerControllerI.setInitialValues();
        playerMaxPos = playerControllerI.getInitialPosition();
    }
    public void SetGameState(GameState newGameState)
    {
        currentGameState = newGameState;
    }
    #endregion
    IEnumerator gameOverC()
    {
        playerControllerI.die();
        yield return new WaitForSeconds(0.2f);

        SetGameState(GameState.GameOver);
        if (PlayerPrefs.HasKey("MaxScore"))
        {
            if (PlayerPrefs.GetFloat("MaxScore") < Score)
            {
                PlayerPrefs.SetFloat("MaxScore", Score);
                newMaxScore = true;
            }
        }
        else
            PlayerPrefs.SetFloat("MaxScore", Score);
        yield return new WaitForSeconds(1.8f);
        player.GetComponent<Rigidbody2D>().simulated = false;
        CanvasManager.SI.setCanvasInGameOver();
        if (newMaxScore)
        {
            FindObjectOfType<GameOverPlat>().setNewMaxScoreText();
            SoundControllerPlatform.SI.playSound("NewMaxScore");
        }
        else
        {
            FindObjectOfType<GameOverPlat>().setMaxScoreText();
        }
        LvlGenerator.SI.destroyAllLvl();
        FindObjectOfType<EnemyGenerator>().DestroyAllEnemies();
    }
    //Getter y setter
    public float getScore()
    {
        return this.Score;
    }
    public void addScore(float Score = 0)
    {
        this.Score += Score == 0 ? 1 : Score;
    }
    //Load Scenes
    public void returnMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
