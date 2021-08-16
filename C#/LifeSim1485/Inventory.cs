using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   
    public InventoryScriptable inventoryScriptable;
    public updateStats updateS;

    //items
    public ItemObject mushrooms;
    public ItemObject wood;
    public ItemObject berries;
    public ItemObject axe;
    public ItemObject leather;
    public ItemObject coins;
    public ItemObject stick;
    public ItemObject bow;
    public ItemObject soup;



    //public int coinsID = 0;
    //public int mushroomsID = 1;
    //public int berriesID = 2;
    //public int woodID = 3;
    //public int axeID = 4;
    //public int leatherID = 5;




    public Text mushroomsButtonText;
    public Text woodButtonText;
    public Text berriesButtonText;
    public Text axeButtonText;
    public Text leatherButtonText;



    public Text coinsText;

    public EquipmentScript equipment;


    public GameObject mushroomButton;
    public GameObject woodButton;
    public GameObject berriesButton;
    public GameObject axeButton;
    public GameObject leatherButton;



    public Text LogText;

    public ActivateDeactivate activateDeactivate;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    





    

    public void addSomething(ItemObject item, int amount)
    {

        //mushrooms = mushrooms + amount;
        inventoryScriptable.AddItem(new Item(item), amount);
        //mushroomsButtonText.text = "   " + mushrooms + " mushroom";
        //activateDeactivate.logUpdateMenustart();
        //LogText.text = "";
        //LogText.text = LogText.text + "\n+ " + amount + item.name;
        updateS.logLine.Add(amount + " <color=orange>" + item.name + "</color>.");

        //print("total now " + inventoryScriptable.getAmount(new Item(item)) + " of " + item.Name);
        
}


    public void addSomethingNoLog(ItemObject item, int amount)
    {

        //mushrooms = mushrooms + amount;
        inventoryScriptable.AddItem(new Item(item), amount);
        //mushroomsButtonText.text = "   " + mushrooms + " mushroom";
        //activateDeactivate.logUpdateMenustart();
        //LogText.text = "";
        //LogText.text = LogText.text + "\n+ " + amount + item.name;
       // updateS.logLine.Add(amount + " <color=orange>" + item.name + "</color>.");

        //print("total now " + inventoryScriptable.getAmount(new Item(item)) + " of " + item.Name);

    }




    public void ConsumeItem(ItemObject _item)
    {
        Debug.Log(new Item(_item).Name);
        int hpToReg = new Item(_item).buffs[0].value;
        int moodToReg = new Item(_item).buffs[1].value;
        updateS.AddHealth(hpToReg);
        updateS.AddMood(moodToReg);
        addSomething(_item, -1);
    }

    public void craftBow()
    {
        
        addSomething(bow, 1);
        addSomething(stick, -20);

    }


    public void addSet()
    {
        addSomething(equipment.craftedEquipment, 1);
        addSomething(coins, 100);
        
    }

    /*
        public void addAxe()
        {

            //axe = 1;
            inventoryScriptable.AddItem(axe, 1);
            axeButtonText.text = "   " + axe + " axe";
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n+ " + axe + " axe";

        }

        /* public void takeAwayMushrooms(int amount)
         {
             //mushrooms = mushrooms - amount;

             mushroomsButtonText.text = "   " + mushrooms + " mushroom";
             activateDeactivate.logUpdateMenustart();

             LogText.text = LogText.text + "\n- " + amount + " mushroom";
        } 


        public void addCoins(int amount)
        {

        //coins = coins + amount;
            inventoryScriptable.AddItem(coins, amount);
            coinsText.text = "Coins: " + coins;
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n+ " + amount + " coins";

        }

      /* public void takeAwayCoins(int amount)
        {
            //coins = coins - amount;
            coinsText.text = "Coins: " + coins;
            activateDeactivate.logUpdateMenustart();

            LogText.text = LogText.text + "\n- " + amount + " coins";
        }




        public void addwood(int amount)
        {
            // wood = wood + amount;
            inventoryScriptable.AddItem(coins, amount);
            woodButtonText.text = "   " + wood + " wood";
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n+ " + amount + " wood";
        }

        public void takeAwaywood(int amount)
        {
          //  wood = wood - amount;
            woodButtonText.text = "   " + wood + " wood";
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n+ " + amount + " wood";
        }

        public void addberries(int amount)
        {
         //  berries = berries + amount;
            berriesButtonText.text = "   " + berries + " berries";
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n+ " + amount + " berries";
        }

        public void takeAwayberries(int amount)
        {
          //  berries = berries - amount;
            berriesButtonText.text = "   " + berries + " berries";
            activateDeactivate.logUpdateMenustart();
            LogText.text = LogText.text + "\n- " + amount + " berries";
        }


        // Update is called once per frame
        void Update()
        {
            /*
            if (mushrooms == 0)
            {
                mushroomButton.SetActive(false);
            }
            else
            {
                mushroomButton.SetActive(true);
            }

            if (berries == 0)
            {
                berriesButton.SetActive(false);
            }
            else
            {
                berriesButton.SetActive(true);
            }
            if (wood == 0)
            {
                woodButton.SetActive(false);
            }
            else
            {
                woodButton.SetActive(true);
            }
            if (axe == 0)
            {
                axeButton.SetActive(false);
            }
            else
            {
                axeButton.SetActive(true);
            }





        }

        */

    public void LoadInventory()
    {
        /*
                mushrooms = ES3.Load<int>("mushrooms");
                wood = ES3.Load<int>("wood");
                berries  = ES3.Load<int>("berries");
                coins = ES3.Load<int>("coins");
                axe = ES3.Load<int>("axe");

            */

        inventoryScriptable.Load();
        print("inventory loaded");
        //update objects
        mushroomsButtonText.text = "   " + mushrooms + " mushroom";
        woodButtonText.text = "   " + wood + " wood";
        berriesButtonText.text = "   " + berries + " berries";
        axeButtonText.text = "   " + axe + " axe";
        coinsText.text = "Coins: " + coins;



    }


    private void OnApplicationQuit()
    {
        inventoryScriptable.Container.Items = new InventorySlot[28];
    }

 

}
