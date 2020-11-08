using System;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    private Slider _life;

    private void Awake()
    {
        _life = GetComponent<Slider>();
    }

    private void Update()
    {
        _life.value = PlayerController.ShIn.Life;
    }
}