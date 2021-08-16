using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeptManager : MonoBehaviour
{
    public updateStats statsU;
    public GameObject deptMenu;
    public Text deptText;
    public GameObject nothingToDoMenu;
    public int deptNumber = 0;
    public int deptDaysLeft = -1;
    public Inventory inventory;
    public GameObject notEnoughCoins;
    public int currentDay=0;
    // Start is called before the first frame update
    void Start()
    {
        deptNumber = 0;
        deptDaysLeft = -1;
        currentDay = statsU.day;
    }


    public void villageDept()
    {
        deptNumber = 1;
        deptMenu.SetActive(true);
        deptText.text = "Do you want to pay 10000 coins to cover your debt? You have " + deptDaysLeft + " days left.";
    }
    public void townDept()
    {
        deptNumber = 2;
        deptMenu.SetActive(true);
        deptText.text = "Do you want to pay 20000 coins to cover your debt? You have " + deptDaysLeft + " days left.";
    }

    public void villageDeptPay()
    {

        if (deptNumber == 1)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 10000)
            {
                inventory.addSomething(inventory.coins, -10000);
                statsU.dept = -1;
                deptDaysLeft = -1;
                deptMenu.SetActive(false);
            }
            else
            {
                deptMenu.SetActive(false);
                //equipmentWarning.text = "Not enough coins.";
                notEnoughCoins.SetActive(true);
            }


        }else if (deptNumber == 2)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 20000)
            {
                inventory.addSomething(inventory.coins, -20000);
                statsU.dept = -2;
                deptDaysLeft = -1;
                deptMenu.SetActive(false);
            }
            else
            {
                deptMenu.SetActive(false);
                //equipmentWarning.text = "Not enough coins.";
                notEnoughCoins.SetActive(true);
            }

        }
    }



    public void nothingToDoHere()
    {
        nothingToDoMenu.SetActive(true);

    }


    public void loadAll()
    {
        deptDaysLeft = ES3.Load<int>("deptDaysLeft");
        
    }

    public void saveAll()
    {
        ES3.Save<int>("deptDaysLeft", deptDaysLeft);
       
    }


    // Update is called once per frame
    void Update()
    {
        if (statsU.day > currentDay)
        {
            if(deptDaysLeft >= 1)
            {
                deptDaysLeft = deptDaysLeft - 1;
            }
            if (deptDaysLeft ==  0)
            {
                statsU.GameOver();
            }
            currentDay = statsU.day;
        }
        
    }
}
