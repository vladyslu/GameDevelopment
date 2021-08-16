using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour
{

    public Inventory inventory;
    public updateStats statsU;

    public Slider hoursSlider;
    public ActivateDeactivate activateDeactivate;
    public Text equipmentWarning;
    public GameObject equipmentWarningMenu;

    public GameObject YouNeedAnAxeMenu;
    public GameObject YouNeedABowMenu;
    public EquipmentScript equipment;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Sleep()
    {
       // if(hoursSlider.value > statsU.hoursLeft)
     //   {
      //      activateDeactivate.CannotSleepSoMuchMenustart();
      //  }
      //  else 
      //  {

            int value = (int)hoursSlider.value;
            statsU.MinusHours(value);
            statsU.AddMood(value * statsU.restMultiplier);
            activateDeactivate.howLongToRestMenuClose();
            hoursSlider.value = 0;

      //  }
    }

    public void Gathering()
    {
        statsU.MinusHours(1);
        statsU.MinusMood(2);
        int RandomNumber = Random.Range(0, 9);
     
      if (RandomNumber <= 7)
        {
           inventory.addSomething(inventory.berries, 1);
            

        }


        RandomNumber = Random.Range(0, 9);
        if (RandomNumber <= 2)
        {
            inventory.addSomething(inventory.mushrooms, 1);
        }

        
            inventory.addSomething(inventory.stick, 2);
        



    }


    
    
    public void woodCollecting()
    {
        
        if(inventory.inventoryScriptable.getAmount(new Item(inventory.axe)) > 0)
        {

            statsU.MinusHours(1);
            statsU.MinusMood(5);
            int RandomNumber = Random.Range(3, 10);
            inventory.addSomething(inventory.wood, RandomNumber);
            inventory.addSomething(inventory.stick, 3);

        }
        else
        {
            YouNeedAnAxeMenu.SetActive(true);
        }
        
    }


    public void hunting()
    {

        if (inventory.inventoryScriptable.getAmount(new Item(inventory.bow)) > 0)
        {

            statsU.MinusHours(2);
            statsU.MinusMood(10);
            int RandomNumber = Random.Range(1, 2);
            inventory.addSomething(inventory.leather, RandomNumber);
           // inventory.addSomething(inventory.stick, 2);

        }
        else
        {
            YouNeedABowMenu.SetActive(true);
        }

    }



    //jobs start here




      public void cookerJob()
    {
        if (equipment.currentEquipment == equipment.cookingEquipment)
        {
            inventory.addSomething(inventory.coins, 10);
            statsU.MinusHours(2);
            statsU.MinusMood(10);
        }
        else
        {
            equipmentWarningMenu.SetActive(true);
            equipmentWarning.text = "Cooking equipment is required.";
        }
    }

    public void bartenderJob()
    {
        if (equipment.currentEquipment == equipment.bartenderEquipment)
        {
            inventory.addSomething(inventory.coins, 20);
        statsU.MinusHours(2);
        statsU.MinusMood(14);
    }
        else
        {
            equipmentWarningMenu.SetActive(true);
            equipmentWarning.text = "Bartender equipment is required.";
        }
    }

    public void farmerJob()
    {
        if (equipment.currentEquipment == equipment.farmerEquipment)
        {
            inventory.addSomething(inventory.coins, 25);
        statsU.MinusHours(2);
        statsU.MinusMood(14);
        }
        else
        {
            equipmentWarningMenu.SetActive(true);
            equipmentWarning.text = "Farming equipment is required.";
        }
    }

    public void carpentenderAprJob()
    {
        if (equipment.currentEquipment == equipment.carpenderEquipment)
        {
            inventory.addSomething(inventory.coins, 35);
        statsU.MinusHours(2);
        statsU.MinusMood(12);
    }
        else
        {
            equipmentWarningMenu.SetActive(true);
            equipmentWarning.text = "Carpentender equipment is required.";
        }
    }


    public void smithAprJob()
    {
        if (equipment.currentEquipment == equipment.smithEquipment)
        {
        inventory.addSomething(inventory.coins, 50);
        statsU.MinusHours(2);
        statsU.MinusMood(14);
}
        else
        {
            equipmentWarningMenu.SetActive(true);
            equipmentWarning.text = "Smith equipment is required.";

        }
    }







    /*
        public void eatMushroom()
        {
            if(inventory.mushrooms.amount > 0){
                statsU.MinusHours(1);
                statsU.AddHealth(2);
                inventory.addSomething(inventory.mushrooms, -1);

            }

        }

        public void eatBerries()
        {
            if (inventory.berries.amount > 0)
            {
                statsU.MinusHours(1);
                statsU.AddHealth(1);
                inventory.addSomething(inventory.mushrooms, -1);

            }

        }

        */
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
