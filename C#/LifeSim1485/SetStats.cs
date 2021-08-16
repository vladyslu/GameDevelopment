using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetStats : MonoBehaviour
{
    public Slider sliderHealth;
    public Slider sliderMood;


  


    public void SetMaxHealth(int health)
    {
        sliderHealth.maxValue = health;
        sliderHealth.value = health;

    }

    public void SetMaxMood(int mood)
    {
        sliderMood.maxValue = mood;
        sliderMood.value = mood;

    }


    public void setHealth(int health)
    {
        sliderHealth.value = health;


    }

    public void setMood(int mood)
    {
        sliderMood.value = mood;


    }

}
