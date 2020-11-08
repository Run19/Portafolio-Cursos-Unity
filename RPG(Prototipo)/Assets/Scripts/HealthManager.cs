using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public  int maxplayerLife;
    public int currentLife;


    public GameObject posPoint;
    public GameObject deadParticles;

    //Vars para hacer toggle
    public bool flashActive;
    public float flashLenght;
    private float flashCounter;
    private SpriteRenderer characeterRenderer;

    private float timeToDestroy=2;


    public int expWhenDefeat;
    
    void Start()
    {
        characeterRenderer = GetComponent<SpriteRenderer>();
        currentLife = maxplayerLife;
        flashActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLife <= 0) {
            if (deadParticles != null) {
                GameObject particleDead=Instantiate(deadParticles, posPoint.transform.position, posPoint.transform.rotation);
                
            }
            if (gameObject.tag.Equals("Enemy")) {
                GameObject.Find("Player").GetComponent<CharacterStats>().addXp(expWhenDefeat);
            }



            gameObject.SetActive(false);
        }
        
        
        if (flashActive) {//Hacemos el flash que se dara en cada situación a partir de el tiempo total del flash.
            flashCounter -= Time.deltaTime;
            if (flashCounter > flashLenght * 0.66) { toggleColor(false); }
            else if (flashCounter > flashLenght * 0.33) { toggleColor(true); }
            else if (flashCounter > 0) { toggleColor(false); }
            else {
                toggleColor(true);
                flashActive = false;
            }
        }
    }


    public void DamageCharacter(int damage) {

        if (!flashActive) {
            currentLife -= damage;
        }
        if (flashLenght > 0) {//Activa el flash cuando el jugador recibio un golpe, ademas de que comprueba que no sea un enemigo
            flashActive = true;
            flashCounter = flashLenght;
        }
    
    }

    //Cambiar el color 
    private void toggleColor(bool visible) {
        characeterRenderer.color = 
            new Color(characeterRenderer.color.r,
            characeterRenderer.color.g,
            characeterRenderer.color.b, 
            (visible?1.0f:0.0f));//Si es visible la intensidad es 1, si no es 0
    }

    public void updateMaxHealth(int newMaxHealth) {
        maxplayerLife = newMaxHealth;
        currentLife = maxplayerLife;
    }
}
