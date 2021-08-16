using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodes : MonoBehaviour
{
    public InputField cheat;
    public Inventory inventory;
    public GameObject worksMenu;
    public Text worksText;
    //public GameObject Player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void check()
    {
        if(cheat.text == "kickstart")
        {
            inventory.addSet();
            worksText.text = "Yay. It Works.";
            worksMenu.SetActive(true);
            cheat.text = "";

        }
        else
        {
            worksText.text = "Sorry. Cheat not found. Try again.";
            worksMenu.SetActive(true);
            cheat.text = "";
        }
    }
 




    // Update is called once per frame
    void Update()
    {
        
    }
}
