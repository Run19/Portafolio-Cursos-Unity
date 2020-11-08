using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class ParallaxBackground : MonoBehaviour
{
    private float width;
    private Vector3 initialPosition;


    private void Awake()
    {
        initialPosition = this.transform.position;
        width = (transform.GetComponent<SpriteRenderer>().bounds.size.x * 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            this.transform.position = new Vector3(this.transform.position.x + width, this.transform.position.y, this.transform.position.z);
        }
    }
    public void setInitialPosition()
    {
        transform.position = initialPosition;
    }
}
