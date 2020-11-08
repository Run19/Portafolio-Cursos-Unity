using System;
using UnityEngine;

public enum GameState
{
    InGame,
    Menu
}

public class GameManager : MonoBehaviour
{
    private GameState _currentGameState;
    private float _playerScore;
    public static GameManager SingleInstance;
    private float _life;
    private GameObject _playerKnife;
    [SerializeField, Range(1, 10)] private float maxLife;

    private void Awake()
    {
        if (SingleInstance == null)
            SingleInstance = this;

        _playerKnife = GameObject.FindGameObjectWithTag("knife");
    }

    private void Start()
    {
        StartGame();
    }


    private void Update()
    {
        if (_currentGameState == GameState.InGame)
            ChangeLife(false, Time.deltaTime / 10);
    }

    private void StartGame()
    {
        ChangeGameState(GameState.InGame);
        GUIManager.SingleInstance.ChangeCanvas(_currentGameState);
        SetPlayerValues(true);
        GUIManager.SingleInstance.UpdateScore();
    }

    private void GameOver()
    {
        GUIManager.SingleInstance.UpdateScore();
        ChangeGameState(GameState.Menu);
        SetPlayerValues(false);
        GUIManager.SingleInstance.ChangeCanvas(_currentGameState);
    }

    private void SetPlayerValues(bool playing)
    {
        _playerKnife.SetActive(playing);

        if (!playing) return;
        _playerScore = 0;
        _life = maxLife;
    }

    #region Setters and Getters

    private void ChangeGameState(GameState lNewGameState)
    {
        _currentGameState = lNewGameState;
    }

    public GameState GetCurrGameState()
    {
        return _currentGameState;
    }

    public float GetScore()
    {
        return _playerScore;
    }

    public void SetScore(bool lWin, float points)
    {
        _playerScore = lWin ? _playerScore + points : _playerScore - points;
    }

    public float GetLife()
    {
        return _life;
    }

    public void ChangeLife(bool win, float lifeChanger = 1)
    {
        _life = win ? _life < maxLife ? _life + lifeChanger : _life : _life - lifeChanger;

        if (_life <= 0)
            GameOver();
    }

    #endregion
}