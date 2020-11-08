using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class esceneChange : MonoBehaviour
{

    public string newPlaceName = "NewScene";

    public string destinyZone = "New Escene Name Here";
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            FindObjectOfType<PlayerControler>().nextScene=destinyZone;
            SceneManager.LoadScene(newPlaceName);

        } 
    }
}
