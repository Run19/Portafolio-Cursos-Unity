using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MainMenyu : MonoBehaviour
{

    int currentMode;
    int currentDificult;
    public TextMeshProUGUI mode;
    public TextMeshProUGUI difficult;
    void Start()
    {
        currentMode = 1;
        currentDificult = 1;
        setDiff();
    }

    public void ChangeMode()
    {
        currentMode = currentMode == 0 ? 1 : 0;
        if (currentMode == 0)
        {
            mode.text = "Mode:Mouse";
        }
        else
        {
            mode.text = "Mode:Keyboard[S-W]";
        }
    }
    public void ChangeDif()
    {
        
        if (currentDificult <4)
        {
            currentDificult++;
        }
        else
        {
            currentDificult = 1;
        }
        setDiff();
    }

    private void setDiff()
    {
        switch (currentDificult)
        {
            case 1:
                difficult.text = "Noob";
                Enemy.SI.noob();
                break;
            case 2:
                difficult.text = "Normal";
                Enemy.SI.easy();
                break;
            case 3:
                difficult.text = "PRO";
                Enemy.SI.Hard();
                break;
            case 4:
                difficult.text = "INSANE";
                Enemy.SI.Insane();
                break;
        }
    }

    private void OnEnable()
    {
        setDiff();
    }
}
