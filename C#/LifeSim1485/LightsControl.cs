using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;

public class LightsControl : MonoBehaviour
{
    public GameObject lightsObject;
    public updateStats statsU;
    private float angleToRotate;
    private float colorNumber;
    private Color colorMorning = new Color(204f / 255f, 152f / 255f, 160f / 255f);
    private Color colorDay = new Color(255f / 255f, 255f / 255f, 255f / 255f);
    private Color colorEvening = new Color(104f / 255f, 33f / 255f, 65f / 255f);
    private Color colorNight = new Color(74f / 255f, 14f / 255f, 14f / 255f);

    public Light2D MyLight; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void rotateLightObject()
    {
        
       // print("Angle" + angleToRotate);
       // lightsObject.transform.Rotate(0.0f, 0.0f, 15f, Space.Self);
    }


    // Update is called once per frame
    void Update()
    {
        angleToRotate = (statsU.hoursLeft * 360) / 24;
        lightsObject.transform.localEulerAngles = new Vector3(0, 0, angleToRotate);
            if(0 < statsU.hoursLeft && statsU.hoursLeft <= 5)
           {

           // colorNumber = statsU.hoursLeft;
           // print("colorN is " + colorNumber);
            //color = new Color(colorNumber, colorNumber, colorNumber);
              MyLight.color = colorNight;



        }
        else if (19 < statsU.hoursLeft && statsU.hoursLeft <= 24)
        {
            //colorNumber = statsU.hoursLeft;
           // print("colorN is " + colorNumber);
           // color = new Color(colorNumber, colorNumber, colorNumber);
            MyLight.color = colorMorning;
        }
        else if (10 < statsU.hoursLeft && statsU.hoursLeft <= 19)
        {
            MyLight.color = colorDay;
        }
        else if (5 < statsU.hoursLeft && statsU.hoursLeft <= 10)
        {
            MyLight.color = colorEvening;
        }



    }
}
