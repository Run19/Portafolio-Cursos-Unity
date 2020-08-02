using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dieOnTime : MonoBehaviour
{
    public float timeToDead = 2;
    private float timing=0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timing > timeToDead)
        {
            Destroy(this.gameObject);
        }
        timing += Time.deltaTime;
    }
}
