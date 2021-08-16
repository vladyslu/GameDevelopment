using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public EquipmentScript equipment;
    public Inventory inventory;
    public Slider SellSlider;
    public Slider BuySlider;
    public Text silderIndicatorText;
    public Text priceText;

    public int itemID;
    public int amountToSell;
    public int amountToBuy;

    public GameObject SellMenu;
    public GameObject BuyMenu;
    public GameObject notEnoughMoneyMenu;
  
    ItemObject ItemToSell;
    ItemObject ItemToBuy;
    // int mushroomsPrice = 2;
    // int berriesPrice = 1;
    //  int axePrice = 20;

    // Start is called before the first frame update
    void Start()
    {
        itemID = -1; 
    }

    public void buyAxe()
    {
       startBuying(inventory.axe);

    }

    public void buyCookingSet()
    {
        startBuying(equipment.cookingEquipment);

    }

    public void buyFarmingSet()
    {
        startBuying(equipment.farmerEquipment);

    }
    public void buySmithSet()
    {
        startBuying(equipment.smithEquipment);

    }

    public void buyCarpendSet()
    {
        startBuying(equipment.carpenderEquipment);

    }


    public void buyBartenderSet()
    {
        startBuying(equipment.bartenderEquipment);

    }

    public void buyCitizenSet()
    {
        startBuying(equipment.officialEquipment);

    }

    public void buySoup()
    {
        startBuying(inventory.soup);

    }




    public void sellMushroom()
    {

       startSelling(inventory.mushrooms);

    }

    public void sellBerries()
    {
        startSelling(inventory.berries);
    }



 









    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public void startSelling(ItemObject _item)
    {
        ItemToSell = _item;


        SellSlider.maxValue = inventory.inventoryScriptable.getAmount(new Item(_item));
       // print("item amount is " + _item.amount);

        SellMenu.SetActive(true);



        
    }

   public void finishSelling()
    {
        if (amountToSell > 0)
        {
            Item itemSelling = new Item(ItemToSell);
            Item coinItem = new Item(inventory.coins);

            inventory.inventoryScriptable.AddItem(itemSelling, -amountToSell);
            inventory.inventoryScriptable.AddItem(coinItem, ItemToSell.sellPrice * amountToSell);
            print("item amount is " + inventory.inventoryScriptable.getAmount(itemSelling));
            //inventory.inventoryScriptable.AddItem(inventory.coins, item.price *  amountToSell);






        }
        SellMenu.SetActive(false);




    }


    public void startBuying(ItemObject _item)
    {
        
        ItemToBuy = _item;
       // Item itemBuying = new Item(ItemToBuy);

        priceText.text = "The price for this item is " + ItemToBuy.buyPrice + " coins.";

        BuyMenu.SetActive(true);
        
    }


  
    public void finishBuying()
    {
        Item coinItem = new Item(inventory.coins);
        Item itemBuying = new Item(ItemToBuy);
        if (inventory.inventoryScriptable.getAmount(coinItem) >= ItemToBuy.buyPrice)
        {



            inventory.inventoryScriptable.AddItem(itemBuying, 1);
            inventory.inventoryScriptable.AddItem(coinItem, -itemBuying.buyPrice);
            //inventory.inventoryScriptable.AddItem(inventory.coins, item.price *  amountToSell);




        }
        else
        {
            notEnoughMoneyMenu.SetActive(true);
        }

       // }
        BuyMenu.SetActive(false);
    }
    

 
    // Update is called once per frame
    void Update()
    {
        
        silderIndicatorText.text = "" + SellSlider.value;
        amountToSell = (int)SellSlider.value;


    }
}
