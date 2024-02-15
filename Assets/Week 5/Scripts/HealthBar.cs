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
        slider.value = health;
        SendMessage("HealthBar", slider.value, SendMessageOptions.DontRequireReceiver);
    }

    public void TakeDamage(float damage)
    {
        slider.value -= damage;

        //save value of health to PlayerPrefs
        SaveHealth();
    }

    public void SaveHealth()
    {
        //health saved by using PlayerPrefs
        PlayerPrefs.GetFloat("HealthBarValue", slider.value);
    }
}