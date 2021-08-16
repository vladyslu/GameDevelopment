using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationManager : MonoBehaviour
{
    public int currentLocation;
    
    public int homeID;
    public int forestID;
    public int villageID;
    public int villageMarketID;
    public int townID;


    public Sprite forestShackBackground;


    public AudioSource steps;

    public GameObject homeArea;
    public GameObject forestArea;
    public GameObject villageArea;
    public GameObject townArea;
    public GameObject villageMarketArea;
    public buttonsToDeactivate buttonsToDeactivate;

    public ActivateDeactivate ActivateDeactivate;

    public Inventory inventory;
    public updateStats statsU;
    public GameObject NotEnoughWoodMenu;
    public GameObject buyMenu;
    public Text buyMenuText;
    public GameObject NotEnoughCoins;
    public GameObject shouldDebtFirst;
    
    private void goHome()
    {

        currentLocation = homeID;
        deactivateAllAreas(); 
        homeArea.SetActive(true);
       


    }

    private void goForest()
    {
        currentLocation = forestID;
        deactivateAllAreas();
        forestArea.SetActive(true);
        ActivateDeactivate.forestMenustart();
    }

    private void goTown()
    {
        currentLocation = townID;
        deactivateAllAreas();
        townArea.SetActive(true);
        ActivateDeactivate.townMenuStart();
    }

    private void goVillage()
    {

        currentLocation = villageID;
        deactivateAllAreas();
        villageArea.SetActive(true);
        ActivateDeactivate.VillageMenustart();
    }

    private void goVillageMarket()
    {
        currentLocation = villageMarketID;
    }


    public void moveToForest()
    {
        if(inventory.inventoryScriptable.getAmount(new Item(inventory.wood)) >= 50)
        {

            inventory.addSomething(inventory.wood,-50);
            statsU.MinusHours(10);
            statsU.MinusMood(20);
            loadHome(forestID);
            homeArea.SetActive(false);
            forestArea.SetActive(true);
            buttonsToDeactivate.forrestShackDiactivated();
        }
        else
        {
            NotEnoughWoodMenu.SetActive(true);
        }
        
    }

    public void moveToVillage()
    {
        if (inventory.inventoryScriptable.getAmount(new Item(inventory.coins)) >= 5000 && statsU.currentMood >= 21)
        {

            inventory.addSomething(inventory.coins, -5000);
            statsU.MinusHours(10);
            statsU.MinusMood(20);
            loadHome(villageID);
            homeArea.SetActive(false);
            villageArea.SetActive(true);
            buttonsToDeactivate.villageHouseDiactivated();
            buyMenu.SetActive(false);
        }
        else
        {
           
            NotEnoughCoins.SetActive(true);
        }

    }

    public void buyVillageHouse()
    {

        
        buyMenu.SetActive(true);
        
       buyMenuText.text = "You need 5000 coins to purchase this house. You will be able to restore more mood per hour here.";


    }



    public void loadHome(int _home)
    {
        homeID = _home;
        if(_home == forestID)
        {
            //find background
            forestArea.transform.Find("Ground").GetComponent<Image>().sprite = forestShackBackground;
        }
        
    }

    public void deactivateAllAreas()
    {
        homeArea.SetActive(false);
        forestArea.SetActive(false);
        villageArea.SetActive(false);
        townArea.SetActive(false);
    }

    public void updateLocation(int destination)
    {
        if(destination != currentLocation) {
             
            StartCoroutine("playSteps");
            if (destination == 0)
        {
                statsU.MinusHours(2);
                goHome();
        }
        else if (destination == 1)
        {
                statsU.MinusHours(2);
                goForest();
        }
        else if (destination == 2)
        {
                statsU.MinusHours(2);
                goVillage();
        }
        else if (destination == 3)
        {
                statsU.MinusHours(2);
                goVillageMarket();
        }
            else if (destination == townID)
            {
                statsU.MinusHours(2);
                goTown();
            }
        }

    }

    public void playStepsButton()
    {
        StartCoroutine("playSteps");
    }


    public IEnumerator playSteps()
    {
        for (int i = 1; i <= 7; i++)
        {
           // Debug.Log("works");

            steps.Play();
            
            yield return new WaitForSeconds(0.14f);

        
    }
}



    // Start is called before the first frame update
    void Start()
    {
        homeID = 0;
        forestID = 1;
        villageID = 2;
        villageMarketID = 3;
        townID = 4;
        currentLocation = 0;
    }



    public void homeButtonPressed()
    {
        updateLocation(homeID);
    }

    public void forestButtonPressed()
    {
        updateLocation(forestID);
    }

    public void villageButtonPressed()
    {
        ActivateDeactivate.VillageMenustart();
        updateLocation(villageID);
        
    }

    public void townButtonPressed()
    {
        if(statsU.dept == 10000)
        {
            shouldDebtFirst.SetActive(true);
        }
        else
        {
            //ActivateDeactivate.VillageMenustart();
            updateLocation(townID);
        }
       

    }


    public void villageMarketButtonPressed()
    {
        updateLocation(villageMarketID);
    }



    // Update is called once per frame
    void Update()
    {
        if (homeID == forestID)
        {
            statsU.restMultiplier = 4;
            
        }
        else if (homeID == villageID)
        {
            statsU.restMultiplier = 7;
        }
        
    }
}
