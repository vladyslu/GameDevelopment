using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public updateStats statsU;
    public Inventory inventory;
    public InventoryScriptable inventoryScriptable;
    public LocationManager locations;
    public buttonsToDeactivate buttonsDeactivated;
    public LoadScirpt loading;
    public AlternativeDialogueSystem dialogueSystem;
    public AlternativeDialogueSystem dialogue2System;
    public BusinessManager businessManager;
    public DeptManager deptManager;
    public NobleBackbone noble;
    public void Save()
    {

        /*inventory
        ES3.Save<int>("mushrooms", inventory.mushrooms);
        ES3.Save<int>("wood", inventory.wood);
        ES3.Save<int>("berries", inventory.berries);
        ES3.Save<int>("coins", inventory.coins);
        ES3.Save<int>("axe", inventory.axe);
        */

        ES3.Save<int>("dialogue2played", dialogue2System.dialogue2played);
        inventoryScriptable.Save();

        //statsu
        ES3.Save<int>("hp",statsU.currentHealth);
        ES3.Save<int>("mood",statsU.currentMood);
        ES3.Save<int>("day",statsU.day);
        ES3.Save<int>("year",statsU.year);
        ES3.Save<int>("hoursLeft",statsU.hoursLeft);
        ES3.Save<int>("damagePerDay", statsU.damagePerDay);
        ES3.Save<int>("restMultiplier", statsU.restMultiplier);
        ES3.Save<int>("dept", statsU.dept);
        ES3.Save<int>("neverShowAreUSureMenu", statsU.neverShowAreUSureMenu);
        ES3.Save<int>("currentLocation", locations.currentLocation);
        ES3.Save<int>("homeID", locations.homeID);
        buttonsDeactivated.saveAllButtons();
        businessManager.saveAll();
        deptManager.saveAll();
        noble.saveAll();
        // To save
        //  autoSaveMgr.Save();
        print("Saved");


    }

    public void SaveAndQuit()
    {

        Save();

        loading.LoadMainMenu();
    }

}
