using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    //public float totalHealth = 400;

    // references

    public Slider healthSlider;

    public static PlayerHealth instance;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        healthSlider.value = Hunter.instance.health / Hunter.instance.totalHealth;
    }
}
