using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI enemy;
    [SerializeField]
    TextMeshProUGUI Player;
    public void Point()
    {
        enemy.text = GameManager.SI.getEPoints().ToString();
        Player.text = GameManager.SI.getPPoints().ToString();
    }

    public void reestartPoint()
    {
        enemy.text = "0";
        Player.text = "0";
    }

}
