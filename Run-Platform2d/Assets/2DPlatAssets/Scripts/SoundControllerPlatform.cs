using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundControllerPlatform : MonoBehaviour
{
    public float timeScale = 1;
    private int currentIndex;
    public static SoundControllerPlatform SI;
    [SerializeField]
    AudioSource soundReproductor, musicReproductor, secondaryMusicReproductor;
    [SerializeField]
    AudioClip[] audioSource = new AudioClip[1];

    [SerializeField]
    AudioClip[] musicClip = new AudioClip[1];
    [SerializeField]
    private float maxVolume, timer;
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    private bool soundEnable = true;

    private void Awake()
    {
        timer = 0;
        SI = SI == null ? this : SI;
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioDict.Add(audioSource[i].name, audioSource[i]);
        }
    }
    private void Update()
    {
        if (!musicReproductor.isPlaying && !secondaryMusicReproductor.isPlaying && soundEnable)
        {
            timer += Time.deltaTime;
            if (timer > 1.0f)
            {
                playMusic();
                timer = 0;
            }
        }
    }

    public void playSound(string audioName)
    {
        soundReproductor.PlayOneShot(audioDict[audioName]);
    }
    public void playMusic()
    {
        currentIndex = UnityEngine.Random.Range(0, musicClip.Length);
        if (!musicReproductor.isPlaying && !secondaryMusicReproductor.isPlaying)
        {
            musicReproductor.PlayOneShot(musicClip[currentIndex]);
        }
        else
        {
            if (musicReproductor.isPlaying)
                StartCoroutine(crossFadeDown(musicReproductor, secondaryMusicReproductor));
            else
                StartCoroutine(crossFadeDown(secondaryMusicReproductor, musicReproductor));
        }
    }
    IEnumerator crossFadeDown(AudioSource low, AudioSource up)
    {
        low.volume = maxVolume;
        yield return new WaitForSeconds(0.1f);
        while (low.volume > 0)
        {
            low.volume -= 0.1f;
            yield return new WaitForSeconds(0.2f);
            if (low.volume < 0.5f && !up.isPlaying)
                StartCoroutine(crossFadeUp(up));
        }
        low.volume = 0;
        low.Stop();
    }
    IEnumerator crossFadeUp(AudioSource reproductor)
    {
        reproductor.volume = 0;
        yield return new WaitForSeconds(0.1f);
        reproductor.PlayOneShot(musicClip[currentIndex]);
        while (reproductor.volume < maxVolume)
        {
            reproductor.volume += 0.1f;
            yield return new WaitForSeconds(0.2f);
        }
        reproductor.volume = maxVolume;
    }

}
