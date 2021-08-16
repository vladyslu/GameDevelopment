using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpWindow : MonoBehaviour
{
    public Text infoText;
    public updateStats statsU;
    public DeptManager deptManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(statsU.dept > 0)
        {
            infoText.text = "Welcome to 1485. Build your way up to royalty, or simply find a way out of this medieval hellhole." +
           "\n\nMood can be restored by resting at home. \n\nHealth can be restored by consuming food from the inventory." +
           "\n\nYou have " + statsU.dept + " to pay off, and you have " + deptManager.deptDaysLeft + " days left to do so.";
        }
        else
        {
            infoText.text = "Welcome to 1485. Build your way up to royalty, or simply find a way out of this medieval hellhole." +
            "\n\nMood can be restored by resting at home. \n\nHealth can be restored by consuming food from the inventory.";
        }
        
    }
}
