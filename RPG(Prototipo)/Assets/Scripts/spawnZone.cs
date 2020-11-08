using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZone : MonoBehaviour
{
    private PlayerControler player;
    private CameraMove cam;
    public Vector2 facingDir= Vector2.zero;

    public string spawnZoneName = "NameOfSpawn";

    
    void Start() 
    {
        player = FindObjectOfType<PlayerControler>();
        cam = FindObjectOfType<CameraMove>();

        if (!player.nextScene.Equals(spawnZoneName))
        {
            return;
        }


        player.transform.position = this.transform.position;
        cam.transform.position = new Vector3(this.transform.position.x,
                                            this.transform.position.y, 
                                            cam.transform.position.z);


        player.lastMovement = facingDir;

    }

}
