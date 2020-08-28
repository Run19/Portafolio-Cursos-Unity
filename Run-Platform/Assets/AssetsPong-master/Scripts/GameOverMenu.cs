using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI GameText;
    IEnumerator winInsane()
    {
        yield return new WaitForSeconds(3.0f);
        //Amazing
    }

    private void OnEnable()
    {

        if (GameManager.SI.getPPoints() > GameManager.SI.getEPoints())
        {
            switch (Enemy.SI.getEnemyDif())
            {
                case enemyDif.Noob:
                    GameText.text = "Congratulations You're not a noob anymore";
                    break;
                case enemyDif.Normal:
                    GameText.text = "Congratulations You're Amazing";
                    break;
                case enemyDif.Hard:
                    GameText.text = "Contragulations You're AWASAME";
                    break;
                case enemyDif.insane:
                    GameText.text = "Are you Ready?";
                    break;
            }
        }
        else
        {
            switch (Enemy.SI.getEnemyDif())
            {
                case enemyDif.Noob:
                    GameText.text = "Even if You Lost You're still great";
                    break;
                case enemyDif.Normal:
                    GameText.text = "Even if You Lost You're still Amazing";
                    break;
                case enemyDif.Hard:
                    GameText.text = "Even if You Lost You're still AWASAME";
                    break;
                case enemyDif.insane:
                    GameText.text = "Well, it's insane, not a bit easy";
                    break;
            }
        }
    }
}
