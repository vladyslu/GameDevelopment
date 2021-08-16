using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessManager : MonoBehaviour
{
    public int farmID = 0;
    public int woodworkingID = 1;
    public int smithyID = 2;
    public int generalStoreID = 3;
    public int tavernID = 4;

    public int farmOwned = 0;
    public int woodworkingOwned = 0;
    public int smithyOwned = 0;
    public int generalStoreOwned = 0;
    public int tavernOwned = 0;

    public int IDtoBuy = -1;

    public int currentDay;

    public updateStats statsU;
    public Text pricer;
    public GameObject buyMenu;
    public Inventory inventory;
    public Text equipmentWarning;
    public GameObject equipmentWarningMenu;

    public void farmStart()
    {
        if(farmOwned == 1)
        {
            equipmentWarning.text = "This business is producing 100 coins a day for you.";
            equipmentWarningMenu.SetActive(true);
        }
        else
        {
            IDtoBuy = farmID;
            buyMenu.SetActive(true);
            pricer.text = "You need 2500 coins. This business may produce 100 coins a day for you.";
        }
    }

    public void woodworkingStart()
    {
        if (woodworkingOwned == 1)
        {
            equipmentWarning.text = "This business is producing 150 coins a day for you.";
            equipmentWarningMenu.SetActive(true);
        }
        else
        {
            IDtoBuy = woodworkingID; 
            buyMenu.SetActive(true);
            pricer.text = "You need 3500 coins. This business may produce 150 coins a day for you.";
        }
    }


    public void smithyStart()
    {
        if (smithyOwned == 1)
        {
            equipmentWarning.text = "This business is producing 200 coins a day for you.";
            equipmentWarningMenu.SetActive(true);
        }
        else
        {
            IDtoBuy = smithyID;
            buyMenu.SetActive(true);
            pricer.text = "You need 5000 coins. This business may produce 200 coins a day for you.";
        }
    }


    public void generalStoreStart()
    {
        if (generalStoreOwned == 1)
        {
            equipmentWarning.text = "This business is producing 250 coins a day for you.";
            equipmentWarningMenu.SetActive(true);
        }
        else
        {
            IDtoBuy = generalStoreID;
            buyMenu.SetActive(true);
            pricer.text = "You need 7000 coins. This business may produce 250 coins a day for you.";
        }
    }


    public void tavernStart()
    {
        if (tavernOwned == 1)
        {
            equipmentWarning.text = "This business is producing 300 coins a day for you.";
            equipmentWarningMenu.SetActive(true);
        }
        else
        {
            IDtoBuy = tavernID;
            buyMenu.SetActive(true);
            pricer.text = "You need 10000 coins. This business may produce 300 coins a day for you.";
        }
    }






    public void buying()
    {
        if(IDtoBuy == farmID)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 2500)
            {
                inventory.addSomething(inventory.coins, -2500);
                farmOwned = 1;
                buyMenu.SetActive(false);
            }
            else
            {
                buyMenu.SetActive(false);
                equipmentWarning.text = "Not enough coins.";
                equipmentWarningMenu.SetActive(true);
            }


        }
        else if (IDtoBuy == woodworkingID)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 3500)
            {
                inventory.addSomething(inventory.coins, -3500);
                woodworkingOwned = 1;
                buyMenu.SetActive(false);
            }
            else
            {
                buyMenu.SetActive(false);
                equipmentWarning.text = "Not enough coins.";
                equipmentWarningMenu.SetActive(true);
            }
        }
        else if (IDtoBuy == smithyID)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 5000)
            {
                inventory.addSomething(inventory.coins, -5000);
                smithyOwned = 1;
                buyMenu.SetActive(false);
            }
            else
            {
                buyMenu.SetActive(false);
                equipmentWarning.text = "Not enough coins.";
                equipmentWarningMenu.SetActive(true);
            }
        }
        else if (IDtoBuy == generalStoreID)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 7000)
            {
                inventory.addSomething(inventory.coins, -7000);
                generalStoreOwned = 1;
                buyMenu.SetActive(false);
            }
            else
            {
                buyMenu.SetActive(false);
                equipmentWarning.text = "Not enough coins.";
                equipmentWarningMenu.SetActive(true);
            }
        }
        else if (IDtoBuy == tavernID)
        {
            if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 10000)
            {
                inventory.addSomething(inventory.coins, -10000);
                tavernOwned = 1;
                buyMenu.SetActive(false);
            }
            else
            {
                buyMenu.SetActive(false);
                equipmentWarning.text = "Not enough coins.";
                equipmentWarningMenu.SetActive(true);
            }
        }
       


    }

    // Start is called before the first frame update
    void Start()
    {
     farmID = 0;
     woodworkingID = 1;
     smithyID = 2;
     generalStoreID = 3;
     tavernID = 4;

       farmOwned = 0;
    woodworkingOwned = 0;
     smithyOwned = 0;
     generalStoreOwned = 0;
     tavernOwned = 0;
        IDtoBuy = -1;

        currentDay = statsU.day;
    }






    public void loadAll()
    {
        farmOwned = ES3.Load<int>("farmOwned");


        woodworkingOwned = ES3.Load<int>("woodworkingOwned");


        smithyOwned = ES3.Load<int>("smithyOwned");


        generalStoreOwned = ES3.Load<int>("generalStoreOwned");


        tavernOwned = ES3.Load<int>("tavernOwned");
     




    }

    public void saveAll()
    {
        ES3.Save<int>("farmOwned", farmOwned);
        ES3.Save<int>("woodworkingOwned", woodworkingOwned);
        ES3.Save<int>("smithyOwned", smithyOwned);
        ES3.Save<int>("generalStoreOwned", generalStoreOwned);
        ES3.Save<int>("tavernOwned", tavernOwned);
    }







    // Update is called once per frame
    void Update()
    {
        if(statsU.day > currentDay)
        {
            if (farmOwned == 1)
            {
                inventory.addSomething(inventory.coins, 100);
            }
            if (woodworkingOwned == 1)
            {
                inventory.addSomething(inventory.coins, 150);
            }
            if (smithyOwned == 1)
            {
                inventory.addSomething(inventory.coins, 200);
            }
            if (generalStoreOwned == 1)
            {
                inventory.addSomething(inventory.coins, 250);
            }
            if (tavernOwned == 1)
            {
                inventory.addSomething(inventory.coins, 300);
            }


            currentDay = statsU.day;
        }
        
    }
}
