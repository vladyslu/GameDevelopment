using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory/New Inventory")]
public class InventoryScriptable : ScriptableObject
{
    public ItemDatabaseObject database;
    public InventoryContainer Container;
    public string saveAddress;




    

    public void AddItem(Item _item, int _amount)
    {

        if (_item.buffs.Length > 10)
        {
            SetEmptySlot(_item, _amount);
            return;
        }

        for (int i = 0; i < Container.Items.Length; i++)
        {
            if (Container.Items[i].ID == _item.ID)
            {
                
                Container.Items[i].AddAmount(_amount);
                return;
            }


        }

       
        SetEmptySlot(_item, _amount);




    }

    public InventorySlot SetEmptySlot(Item _item, int _amount)
    {
        
        for (int i = 0; i < Container.Items.Length; i++)
        {

            if(Container.Items[i].ID <= -1)
            {
                //Debug.Log("item " + _item.Name + " with ID " + i + " got" + _amount);
                Container.Items[i].UpdateSlot(_item.ID, _item, _amount);
                return Container.Items[i];
            }
        }
        //full inventory (did not set up yet)
        return null;
    }



    public void MoveItem(InventorySlot item1, InventorySlot item2) 
    {
        InventorySlot temp = new InventorySlot(item2.ID, item2.item, item2.amount);
        item2.UpdateSlot(item1.ID, item1.item, item1.amount);
        item1.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public void RemoveItem(Item _item)
    {
        for (int i = 0; i < Container.Items.Length; i++)
        {
            if(Container.Items[i].item == _item)
            {
                Container.Items[i].UpdateSlot(-1, null, 0);
            }
        }
    }

    [ContextMenu("Save")]
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, saveAddress));
        formatter.Serialize(file, saveData);
        file.Close();

        //IFormatter formatter = new BinaryFormatter();
        //Stream stream = new FileStream(string.Concat(Application.persistentDataPath, saveAddress), FileMode.Create, FileAccess.Write);
        //formatter.Serialize(stream, Container);
        //stream.Close();

        
    }





    [ContextMenu("Load")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, saveAddress))){

             BinaryFormatter bf = new BinaryFormatter();
             FileStream file = File.Open(string.Concat(Application.persistentDataPath, saveAddress), FileMode.Open);
              JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
          //  InventoryContainer newContainer = (InventoryContainer)bf.Deserialize(stream);
          //  for (int i = 0; i < Container.Items.Length; i++)
           // {
           //     Container.Items[i].UpdateSlot(newContainer.Items[i].ID, newContainer.Items[i].item, newContainer.Items[i].amount);
           // }
            file.Close();

            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(string.Concat(Application.persistentDataPath, saveAddress), FileMode.Open, FileAccess.Read);
            //Container = (InventoryContainer)formatter.Deserialize(stream);
            //InventoryContainer newContainer = (InventoryContainer)formatter.Deserialize(stream);
            
           // stream.Close();


            



        }
    }

    [ContextMenu("Clear")]
    public void Clear()
    {
        Container = new InventoryContainer();
    }


    public int getAmount(Item _item)
    {
        int amount = 0;

        for (int i = 0; i < Container.Items.Length; i++)
        {

           // Debug.Log("itemID to debug " + _item.ID);
            //Debug.Log("Container item " + Container.Items[i].ID);
            if (_item.ID == Container.Items[i].ID)
            {
                amount = Container.Items[i].amount;
                return amount;
            }
        }



        return amount;
    }
 



}




[System.Serializable]
public class InventoryContainer
{

    public InventorySlot[] Items = new InventorySlot[28];


}


[System.Serializable]
public class InventorySlot
{
    public int ID = -1;
    public Item item;
    public int amount;
    


    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;

        // item.amount = amount;
        // item.ID = ID;

    }

    public InventorySlot(int _ID, Item _item, int _amount)
    {
        ID = _ID;
        item = _item;
        amount = _amount;


        // item.amount = amount;
        // item.ID = ID;

    }

    public void UpdateSlot(int _ID, Item _item, int _amount)
    {
        
        ID = _ID;
        item = _item;
        amount = _amount;

        
        // item.amount = amount;
        // item.ID = ID;

    }


    public void AddAmount(int value)
    {
        amount += value;
       

   
    }

}

