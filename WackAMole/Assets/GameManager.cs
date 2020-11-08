using UnityEngine;

public enum GameState
{
    Menu,
    InGame,
    GameOver
}

public enum Difficult
{
    Easy,
    Medium,
    Hard
}

public class GameManager : MonoBehaviour
{
    [Header("Objs Time")] [SerializeField, Range(0, 10)]
    private float difficultEasy;

    [SerializeField, Range(0, 10)] private float difficultMedium, difficultHard;


    [Header("Skull prob"), SerializeField, Range(1, 10)]
    private float skullEz;

    [SerializeField, Range(1, 10)] private float skullMid, skullHard;

    [SerializeField] private GameState _currentGameState;
    public static GameManager singleInstance;
    [SerializeField] public Difficult currentDifficult;


    private float _playerPoints;
    [SerializeField] private float timeMinutes;
    [SerializeField] private float timeSeconds;
    private float _time;
    private int _minutes;
    private int _seconds;


    private void Awake()
    {
        if (singleInstance == null)
            singleInstance = this;
        RestartValues();
    }

    private void Start()
    {
        BackToMenu();
    }

    private void Update()
    {
        if (_currentGameState != GameState.InGame) return;
        _minutes = Mathf.FloorToInt(_time / 60);
        _seconds = Mathf.FloorToInt(_time % 60);
        _time -= Time.deltaTime;
        if (_time < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _currentGameState = GameState.GameOver;
        GUIManager.singleInstance.ChangeState();
    }

    public void PlayGame()
    {
        RestartValues();
        _currentGameState = GameState.InGame;
        GUIManager.singleInstance.ChangeState();
        SetDifficult();
    }

    public void BackToMenu()
    {
        _currentGameState = GameState.Menu;
        GUIManager.singleInstance.ChangeState();
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }


    public void SetDifficult(int newDif)
    {
        if (newDif < 0 || newDif > 3)
        {
            newDif = 1;
        }

        switch (newDif)
        {
            case 1:
                currentDifficult = Difficult.Easy;
                break;
            case 2:
                currentDifficult = Difficult.Medium;
                break;
            case 3:
                currentDifficult = Difficult.Hard;
                break;
        }
    }


    private void SetDifficult()
    {
        switch (currentDifficult)
        {
            case Difficult.Easy:
                Target.ChangeTime(difficultEasy);
                SpawnManager.singleInstance.SetSkullProb(skullEz);
                break;
            case Difficult.Medium:
                Target.ChangeTime(difficultMedium);
                SpawnManager.singleInstance.SetSkullProb(skullMid);
                break;
            case Difficult.Hard:
                Target.ChangeTime(difficultHard);
                SpawnManager.singleInstance.SetSkullProb(skullHard);
                break;
        }
    }


    public void ChangePoints(float points)
    {
        _playerPoints += points;
    }

    public string GetPoints()
    {
        return $"{_playerPoints}";
    }


    public string GetSeconds()
    {
        return $"{_seconds}";
    }

    public string GetMinutes()
    {
        return $"{_minutes}";
    }


    private void RestartValues()
    {
        _time = timeMinutes * 60 + timeSeconds;
        _playerPoints = 0;
    }


    public void LostTime(float lTime)
    {
        _time -= lTime;
    }
}