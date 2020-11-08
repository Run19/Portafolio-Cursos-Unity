using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JokeButton : MonoBehaviour
{
    public Text currentText;
    string[] phrases = new string[8];
    int currentPhrase;
    private void Awake()
    {
        currentPhrase = 0;
        phrases[0] = "IM A RANDOM BUTTON PLEASE DONT CLICK ON ME";
        phrases[1] = "do you know how to read? DON'T TOUCH ME";
        phrases[2] = "Man This button doesn't do anything!";
        phrases[3] = "You could be changing the world\ninstead of being touching me...";
        phrases[4] = "I'M NOT GONNA SHOW YOU THE\n CREDITS, STOP";
        phrases[5] = "DAMN FORGET WHAT I SAID...";
        phrases[6] = "ALI IF YOU'RE READING THIS... I DON'T MISS YOU...";
        phrases[7] = "OK PLS STOP TOUCHING ME";
        currentText.text = phrases[0];
    }
    public void noClickOnMe()
    {
        if (currentPhrase < 7)
        {
            currentPhrase++;
            currentText.text = phrases[currentPhrase];
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }

}
