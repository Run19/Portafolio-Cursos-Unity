using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPlat : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI maxScoreText, playerPoints;
    public void setMaxScoreText()
    {
        maxScoreText.text = $"MAX SCORE:\n{PlayerPrefs.GetFloat("MaxScore")}";
        playerPoints.text = $"Your Score: {GameManager2Dplat.SI.getScore()}";
    }
    public void setNewMaxScoreText()
    {
        maxScoreText.text = $"NEW MAX SCORE:\n{PlayerPrefs.GetFloat("MaxScore")}";
        playerPoints.text = $"YOU'RE AMAZING";
    }
}
