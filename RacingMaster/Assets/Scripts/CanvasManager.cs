using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    Canvas MainMenu, InGame, GameOver;
    public static CanvasManager SI;
    private void Awake()
    {
        SI = SI == null ? this : SI;
    }
    public void setCanvasInGame()
    {
        InGame.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
    }
    public void setCanvasMainMenu()
    {
        InGame.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(true);
    }
    public void setCanvasGameOver()
    {
        InGame.gameObject.SetActive(false);
        GameOver.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
}
