using TMPro;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI time;

    [SerializeField] private GameObject inGame, gameOver, menu;
    public static GUIManager singleInstance;

    private void Awake()
    {
        if (singleInstance == null)
        {
            singleInstance = this;
        }
    }

    private void Update()
    {
        if (GameManager.singleInstance.GetCurrentGameState() != GameState.InGame) return;
        time.text = $"{GameManager.singleInstance.GetMinutes()}:{GameManager.singleInstance.GetSeconds()}";
        score.text = $"{GameManager.singleInstance.GetPoints()}";
    }


    public void ChangeState()
    {
        switch (GameManager.singleInstance.GetCurrentGameState())
        {
            case GameState.Menu:
                inGame.SetActive(false);
                gameOver.SetActive(false);
                menu.SetActive(true);
                break;
            case GameState.InGame:
                inGame.SetActive(true);
                gameOver.SetActive(false);
                menu.SetActive(false);
                break;
            case GameState.GameOver:
                inGame.SetActive(false);
                gameOver.SetActive(true);
                menu.SetActive(false);
                break;
        }
    }
}