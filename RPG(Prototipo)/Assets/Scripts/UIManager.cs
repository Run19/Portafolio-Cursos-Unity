using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Text playerHealthText;
    public Text xpPlayer;
    public Text lvlPlayer;
    public Slider playerHealthBar;
    public HealthManager playerHealthManager;
    public CharacterStats playerStats; 

    // Update is called once per frame
    void Update()
    {
        playerHealthBar.maxValue = playerHealthManager.maxplayerLife;
        playerHealthBar.value = playerHealthManager.currentLife;
        StringBuilder sb = new StringBuilder("HP: ");
        sb.Append(playerHealthManager.currentLife);
        sb. Append("/");
        sb.Append(playerHealthManager.maxplayerLife);
        playerHealthText.text = sb.ToString();


        lvlPlayer.text = $"{playerStats.currentLvl+1}";
        xpPlayer.text = $"XP: {playerStats.currentXP}";



    }





  
    
}
