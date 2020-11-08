using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogZoneScript : MonoBehaviour
{
    public string[] dialog;
    private DialogManager dialogMan;
    private bool playerInZone;



    private void Start()
    {
        dialogMan = FindObjectOfType<DialogManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }


    void Update()
    {
        if(playerInZone && Input.GetMouseButtonDown(1)){
            dialogMan.ShowDialog(dialog);
        }    
    }
}
