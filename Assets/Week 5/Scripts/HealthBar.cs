using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Slider slider;

    public void Start()
    {
        //the use of player prefrences to store knight's health value
        //same method that i attempted in Knight scipt 
        //slider.value = PlayerPrefs.GetFloat("HealthBarValue", slider.value);
        slider.value = PlayerPrefs.GetFloat("health");

        //SendMessage("HealthBar", slider.value, SendMessageOptions.DontRequireReceiver);
    }

    public void UpdateHealth(float health)
    {
        slider.value = health;
    }

}