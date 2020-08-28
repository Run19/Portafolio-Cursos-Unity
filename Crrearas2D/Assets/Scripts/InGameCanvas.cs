using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGameCanvas : MonoBehaviour
{
    [SerializeField]
    private Text time;
    [SerializeField]
    private Text distance;
    [SerializeField]
    private Image countReverseSprite, goImage;
    [SerializeField]
    private Sprite[] spritesCount = new Sprite[4];

    int minutes;
    int seconds;

    void Update()
    {
        minutes = (int)GameManager.SI.getCurrentTime() / 60;
        seconds = (int)GameManager.SI.getCurrentTime() % 60;
        time.text = $"Time\n{minutes}:{seconds}";
        distance.text = $"Distance\n{Math.Round(GameManager.SI.getCurrentScore())}";
    }


    IEnumerator reverseCount()
    {
        SoundManager.SI.playMotoroSound();
        countReverseSprite.gameObject.SetActive(true);
        for (int i = 0; i < spritesCount.Length; i++)
        {
            SoundManager.SI.playReverseCount();
            countReverseSprite.sprite = spritesCount[i];
            yield return new WaitForSeconds(1.0f);
        }
        countReverseSprite.gameObject.SetActive(false);
        SoundManager.SI.playStartGame();
        goImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goImage.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine("reverseCount");
    }
}
