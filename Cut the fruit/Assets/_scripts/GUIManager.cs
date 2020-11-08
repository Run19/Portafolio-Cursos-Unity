using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    public static GUIManager SingleInstance;
    [SerializeField] private GameObject inGame, gameOver;
    [SerializeField] private Slider sliderLife;

    private void Awake()
    {
        if (SingleInstance == null)
            SingleInstance = this;
    }


    public void UpdateScore()
    {
        score.text = GameManager.SingleInstance.GetScore().ToString();
        sliderLife.value = GameManager.SingleInstance.GetLife();
    }

    private void Update()
    {
        if (GameManager.SingleInstance.GetCurrGameState() == GameState.InGame)
            UpdateScore();
    }


    public void ChangeCanvas(GameState currentGameState)
    {
        switch (currentGameState)
        {
            case GameState.InGame:
                inGame.SetActive(true);
                gameOver.SetActive(false);
                break;
            case GameState.Menu:
                gameOver.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(currentGameState), currentGameState,
                    "GameState not Found");
        }
    }
}