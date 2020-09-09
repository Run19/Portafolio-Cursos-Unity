using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SoundManager : MonoBehaviour
{
    public  AudioSource enemy;
    public AudioSource player;
    public static SoundManager SI;
    private void Awake()
    {
        if (SI == null)
        { 
            SI = this;
        }
    }
    public  void playerSound() {
        player.PlayOneShot(player.clip);     
    }
    public void enemySound()
    {
        enemy.PlayOneShot(enemy.clip);
    }

}
