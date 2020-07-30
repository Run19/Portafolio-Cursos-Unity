using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public float velocity;



    void Update()
    {
        if (this.transform.position.x < 2560)
        {
            this.transform.position = new Vector3(this.transform.position.x + velocity * Time.deltaTime, transform.position.y);
        }
        else {
            this.transform.position=new Vector3(512f, transform.position.y);
        }
        
    }
}
