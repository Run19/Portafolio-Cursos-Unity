using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager SI;
    [SerializeField]
    AudioSource audioSoundsReproductor, audioSoundsReproductor2, audioMusicReproductor;
    [SerializeField]
    AudioClip reverseCount, startGame, motor,crashClip;
    [SerializeField]
    AudioClip[] music = new AudioClip[2];

    private void Awake()
    {
        SI = SI == null ? this : SI;
    }
    private void Update()
    {
        if (!audioMusicReproductor.isPlaying)
        {
            playMusicInGame();
        }
    }
    #region music
    public void playMusicInGame()
    {
        if (!audioSoundsReproductor.isPlaying)
            audioMusicReproductor.PlayOneShot(music[Random.Range(0, music.Length)]);
    }
    #endregion
    #region soundInitGame
    public void playReverseCount()
    {
        audioSoundsReproductor.PlayOneShot(reverseCount);
    }

    public void playStartGame()
    {
        audioSoundsReproductor.PlayOneShot(startGame);
    }

    public void playMotoroSound()
    {
        audioSoundsReproductor.PlayOneShot(motor);
    }
    #endregion
    #region gameOverSounds
    
    public void playGameOverSound()
    {
        audioSoundsReproductor.PlayOneShot(crashClip);
    }
    #endregion


    void stopAudioSound(AudioSource audioToStop)
    {
        audioToStop.Stop();
    }

}
