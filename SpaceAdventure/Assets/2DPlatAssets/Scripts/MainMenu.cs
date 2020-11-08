using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    private void Start()
    {
        setText();
    }
    public void setText()
    {
        if (PlayerPrefs.HasKey("MaxScore"))
            text.text = $"MAX SCORE\n{PlayerPrefs.GetFloat("MaxScore")}";
        else
            text.text = "MAX SCORE\n0";
    }
    private void OnEnable()
    {
        setText();
    }
}
