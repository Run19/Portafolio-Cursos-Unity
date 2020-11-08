using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damagePlayer;
    public GameObject damageNumber;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player")) {
            


            if (!collision.gameObject.GetComponent<HealthManager>().flashActive ){
                
                collision.gameObject.GetComponent<HealthManager>()
                    .DamageCharacter(damagePlayer);

                var Clone = (GameObject)Instantiate(damageNumber,
                this.transform.position, Quaternion.Euler(Vector3.zero));
                Clone.GetComponent<DamageNumber>().damagePoints = damagePlayer;
            }
        
        }
    }
}
