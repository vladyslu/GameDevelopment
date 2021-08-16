using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSliderValueScript : MonoBehaviour
{
    public Text theText;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void textUpdate()
    {
        theText.text = slider.value + " hours";
    }
}
