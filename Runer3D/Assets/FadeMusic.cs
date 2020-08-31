using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class FadeMusic : MonoBehaviour
{
    private AudioSource _reproductor;

    private void Awake()
    {
        _reproductor = GetComponent<AudioSource>();
        _reproductor.volume = 0;
    }


    private void Start()
    {
        StartCoroutine(CrossFadeUp());
    }

    public void EndGame()
    {
        StartCoroutine(CrossFadeDown());
    }

    IEnumerator CrossFadeUp()
    {
        for (var i = 0; i < 0.8; i++)
        {
            _reproductor.volume ++;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator CrossFadeDown()
    {
        for (var i = _reproductor.volume; i > 0; i--)
        {
            _reproductor.volume --;
            yield return new WaitForSeconds(0.2f);
        }
    }
}