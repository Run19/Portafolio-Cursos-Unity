using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class InGameCanvas : MonoBehaviour
{
    [SerializeField]
    Slider life, energy;
    [SerializeField]
    TextMeshProUGUI Score, lifeT, energyT;

    private void Start()
    {
        energy.maxValue = playerController.SI.getPlayerEnergy();
        life.maxValue = playerController.SI.getPlayerLife();
    }

    void Update()
    {
        Score.text = $"SCORE:{GameManager2Dplat.SI.getScore(), 1}";
        energy.value = playerController.SI.getPlayerEnergy();
        energyT.text = $"Energy:{Math.Round(playerController.SI.getPlayerEnergy())}";
        life.value = playerController.SI.getPlayerLife();
        lifeT.text = $"Life:{playerController.SI.getPlayerLife() }";
    }
}
