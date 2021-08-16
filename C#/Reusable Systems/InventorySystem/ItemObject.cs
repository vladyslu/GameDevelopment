using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Food,
    Equipment,
    Tool,
    Default,
    Currency
}


public enum Attributes
{
    
    hpRegenerate,
    moodRegenerate,
    appearance
    
}

public abstract class ItemObject : ScriptableObject
{


   //public int amount;

    public int ID;

    public Sprite uiDisplay;
    
    public ItemType type;
    [TextArea(15, 20)] public string description;
    public string Name;
    public int sellPrice;
    public int buyPrice;
   
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        Item newItem = new Item(this);
        return newItem;
    }
    
    




}
[System.Serializable]
public class Item
{

    public string Name;
    public int ID;
    public int sellPrice;
    public int buyPrice;
    

    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {

      
        Name = item.Name;
        ID = item.ID;
        sellPrice = item.sellPrice;
        buyPrice = item.buyPrice;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {

            buffs[i] = new ItemBuff()
            {
                value = item.buffs[i].value,
            appearance = item.buffs[i].appearance,
            attribute = item.buffs[i].attribute
            };
            
        }
        
    }

    

}


[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public Sprite appearance;
    public int value;
    
    
}