using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    GameObject InGame;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    GameObject MainMenu;
    public static CanvasManager SI;

    private void Awake()
    {
        if (SI == null)
        {
            SI = this;
        }
    }

    public void setCanvasInGameOver()
    {
        GameOver.SetActive(true);
        InGame.SetActive(false);
        MainMenu.SetActive(false);
    }
    public void setCanvasInMenu()
    {
        MainMenu.SetActive(true);
        InGame.SetActive(false);
        GameOver.SetActive(false);
    }
    public void setCanvasInGame()
    {
        InGame.SetActive(true);
        GameOver.SetActive(false);
        MainMenu.SetActive(false);
    }

}
