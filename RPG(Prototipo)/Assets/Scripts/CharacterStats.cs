using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentLvl;
    public int currentXP;
    public int[] expToLvlUp;


    public int[] hpLvls,StrengeLvls,defenseLvls;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLvl >= expToLvlUp.Length)
        {
            return;
        }
        else {
            if (currentXP >= expToLvlUp[currentLvl]) {
                currentLvl++;

                //lvlUP
            }
        }
    }

    public void addXp(int xp) {
        currentXP += xp;
    }

}

