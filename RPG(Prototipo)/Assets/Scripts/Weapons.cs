using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    public int weaponDamage;
    [SerializeField]
    private int weaponResistance;

    public GameObject hurtAnim;
    public GameObject hitPoint;
    public GameObject damageNumber;

    List<GameObject> particlesGarbage = new List<GameObject>();

    private float timeToDie=2;
    private float currentTimeToDie;
    
    
    
    private void Update()
    {
        if (particlesGarbage.Count>0) {
            if (currentTimeToDie < 0) {
                foreach (GameObject particle in particlesGarbage)
                {
                    Destroy(particle);
                    currentTimeToDie = timeToDie;
                }
            }
            currentTimeToDie -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<HealthManager>()
                .DamageCharacter(weaponDamage);

            GameObject particlesAnim=Instantiate(hurtAnim, hitPoint.transform.position, hitPoint.transform.rotation);
            particlesGarbage.Add(particlesAnim);
            currentTimeToDie = timeToDie;
            var Clone = (GameObject)Instantiate(damageNumber, 
                        hitPoint.transform.position,Quaternion.Euler(Vector3.zero));

            Clone.GetComponent<DamageNumber>().damagePoints = weaponDamage;
        }
    }
}
