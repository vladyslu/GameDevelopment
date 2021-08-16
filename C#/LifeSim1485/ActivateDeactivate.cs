using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateDeactivate : MonoBehaviour
{
    public GameObject houseMenu;
    public GameObject homeMenu;
    public GameObject forestMenu;
    public GameObject inventoryMenu;

    public Text LogText;


    //pause Menues 
    public GameObject pauseMenu;
    public GameObject loadMenu;
    public GameObject areYouSureToSkipDayMenu;
    public GameObject logUpdateMenu;
    public GameObject CannotSleepSoMuchMenu;
    public GameObject GameOverMenu;
    public GameObject howLongToRestMenu;
    public GameObject VillageMenu;
    public GameObject MarketBuyMenu;
    public GameObject MarketSellMenu;
    public GameObject VillageJobMenu;
    public GameObject OldManMenu;
    public GameObject OldManPlace;
    public GameObject villageBusinessMenu;
    public GameObject townMenu;





    //RightSideMEnues

    public void houseMenustart()
    {
        checkForOpenMenus();

        if (houseMenu.activeSelf == false)
        {
            houseMenu.SetActive(true);
        }

       


    }




    //checking all menues if they are active = to deactivate
    public void checkForOpenMenus()
    {
        if (houseMenu.activeSelf == true)
        {
            houseMenu.SetActive(false);
        }

        if (townMenu.activeSelf == true)
        {
            townMenu.SetActive(false);
        }

        if (villageBusinessMenu.activeSelf == true)
        {
            villageBusinessMenu.SetActive(false);
        }

        if (VillageJobMenu.activeSelf == true)
        {
            VillageJobMenu.SetActive(false);
        }

        if (forestMenu.activeSelf == true)
        {
            forestMenu.SetActive(false);
        }

        if (inventoryMenu.activeSelf == true)
        {
            inventoryMenu.SetActive(false);
        }

        if (homeMenu.activeSelf == true)
        {
            homeMenu.SetActive(false);
        }

        if (VillageMenu.activeSelf == true)
        {
            VillageMenu.SetActive(false);
        }

        if (MarketSellMenu.activeSelf == true)
        {
            MarketSellMenu.SetActive(false);
        }

        if (MarketBuyMenu.activeSelf == true)
        {
            MarketBuyMenu.SetActive(false);
        }


        if (OldManMenu.activeSelf == true)
        {
            OldManMenu.SetActive(false);
            OldManPlace.SetActive(false);
        }






        //    if (areYouSureToSkipDayMenu.activeSelf == true)
        //   {
        //       areYouSureToSkipDayMenu.SetActive(false);
        //   }


    }


    public void OldManMenuStart()
    {
        checkForOpenMenus();

        if (OldManMenu.activeSelf == false)
        {
            OldManMenu.SetActive(true);
            OldManPlace.SetActive(true);
        }


    }

    public void villageBusinessMenuStart()
    {
        checkForOpenMenus();

        if (villageBusinessMenu.activeSelf == false)
        {
            villageBusinessMenu.SetActive(true);
            
        }


    }
    public void townMenuStart()
    {
        checkForOpenMenus();

        if (townMenu.activeSelf == false)
        {
            townMenu.SetActive(true);

        }


    }

    public void forestMenustart()
    {
        checkForOpenMenus();

        if (forestMenu.activeSelf == false)
        {
            forestMenu.SetActive(true);
        }


    }

    public void VillageJobMenuMenustart()
    {
        checkForOpenMenus();

        if (VillageJobMenu.activeSelf == false)
        {
            VillageJobMenu.SetActive(true);
        }


    }

    public void homeMenustart()
    {
        checkForOpenMenus();

        if (homeMenu.activeSelf == false)
        {
            homeMenu.SetActive(true);
        }


    }

    public void inventoryMenustart()
    {
        checkForOpenMenus();

        if (inventoryMenu.activeSelf == false)
        {
            inventoryMenu.SetActive(true);
        }


    }

    public void VillageMenustart()
    {
        checkForOpenMenus();

        if (VillageMenu.activeSelf == false)
        {
            VillageMenu.SetActive(true);
        }


    }
    public void MarketBuyMenuStart()
    {
        checkForOpenMenus();

        if (MarketBuyMenu.activeSelf == false)
        {
            MarketBuyMenu.SetActive(true);
        }


    }

    public void MarketSellMenuStart()
    {
        checkForOpenMenus();

        if (MarketSellMenu.activeSelf == false)
        {
            MarketSellMenu.SetActive(true);
        }


    }




    //pauseMenues

    public void pauseMenustart()
    {
        

        if (pauseMenu.activeSelf == false)
        {
            pauseMenu.SetActive(true);
        }


    }

    public void pauseMenuClose()
    {


        if (pauseMenu.activeSelf == true)
        {
            pauseMenu.SetActive(false);
        }


    }

    public void loadMenustart()
    {


        if (loadMenu.activeSelf == false)
        {
            loadMenu.SetActive(true);
        }


    }


    public void loadMenuClose()
    {


        if (loadMenu.activeSelf == true)
        {
            loadMenu.SetActive(false);
        }


    }


    public void areYouSureToSkipDayMenustart()
    {

        
        if (areYouSureToSkipDayMenu.activeSelf == false)
        {
            areYouSureToSkipDayMenu.SetActive(true);
        }


    }


    public void areYouSureToSkipDayMenuClose()
    {

        
        if (areYouSureToSkipDayMenu.activeSelf == true)
        {
            areYouSureToSkipDayMenu.SetActive(false);
        }


    }


    public void logUpdateMenustart()
    {


        if (logUpdateMenu.activeSelf == false)
        {
            logUpdateMenu.SetActive(true);
        }


    }


    public void logUpdateMenuClose()
    {


        if (logUpdateMenu.activeSelf == true)
        {
            logUpdateMenu.SetActive(false);
            LogText.text = " ";
           

}


    }

    public void CannotSleepSoMuchMenustart()
    {


        if (CannotSleepSoMuchMenu.activeSelf == false)
        {
            CannotSleepSoMuchMenu.SetActive(true);
        }


    }


    public void CannotSleepSoMuchMenuClose()
    {


        if (CannotSleepSoMuchMenu.activeSelf == true)
        {
            CannotSleepSoMuchMenu.SetActive(false);
           


        }


    }



    public void howLongToRestMenuStart()
    {


        if (howLongToRestMenu.activeSelf == false)
        {
            howLongToRestMenu.SetActive(true);
        }


    }


    public void howLongToRestMenuClose()
    {


        if (howLongToRestMenu.activeSelf == true)
        {
            howLongToRestMenu.SetActive(false);
          


        }


    }

    
        public void GameOverMenuStart()
    {


        if (GameOverMenu.activeSelf == false)
        {
            GameOverMenu.SetActive(true);
        }


    }


    public void GameOverMenuClose()
    {


        if (GameOverMenu.activeSelf == true)
        {
            GameOverMenu.SetActive(false);



        }


    }



}
