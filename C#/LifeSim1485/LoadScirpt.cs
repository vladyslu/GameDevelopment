using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScirpt : MonoBehaviour
{

    public SendToSceneScript checker;
    public int loadNumber;
    public updateStats statsU;
    public LocationManager locations;
    public buttonsToDeactivate buttonsDeactivate;

    public Inventory inventory;
    public GameObject loadingScreen;
    public GameObject dialogueScreen;
    public SaveScript saveScript;
    public AlternativeDialogueSystem dialogueSystem;
    public AlternativeDialogueSystem dialogue2System;


    public void Load()
    {
        // var autoSaveMgr = GameObject.Find("Easy Save 3 Manager").GetComponent<ES3AutoSaveMgr>();

        // To load
        //autoSaveMgr.Load();

        statsU.updateAllStats();


        int locationToLoad;
        int homeToLoad;
        locationToLoad = ES3.Load<int>("currentLocation");
        homeToLoad = ES3.Load<int>("homeID");
        dialogue2System.dialogue2played = ES3.Load<int>("dialogue2played");

        locations.updateLocation(locationToLoad);
        locations.loadHome(homeToLoad);
        buttonsDeactivate.loadAllTheButtons();
        saveScript.businessManager.loadAll();
        saveScript.deptManager.loadAll();
        saveScript.noble.loadAll();
        inventory.LoadInventory();

        print("Loaded");

    }
    
    public void LoadMainMenu()
    {
        //inventory.inventoryScriptable.Container.Items = new InventorySlot[28];
        SceneManager.LoadScene("Main Menu");
        //SceneManager.UnloadSceneAsync("LifeSim");
        


    }

    public void Start()
    {
        loadingScreen.SetActive(true);
       
        loadNumber = 0;
    }

    public void NewGame()
    {
        StartCoroutine("waiterNewGame");
    }



    public void Update()
    {
        StartCoroutine("waiter");

    }


    public void checkIfToLoad()
    {
        if (checker.theNumber == 1 && loadNumber == 0)
        {

            loadNumber = 1;
            Load();


            StartCoroutine("waiterLoad");

        }
        else if (loadNumber == 0 && checker.theNumber == 0)
        {
            //print("newgame " + checker.theNumber);
            loadNumber = 1;
            NewGame();


        }
    }

    IEnumerator waiterNewGame()
    {
        yield return new WaitForSeconds(1.0f);
        loadingScreen.SetActive(false);
        dialogueScreen.SetActive(true);
        dialogueSystem.StartFirstDialogue();
    }
    IEnumerator waiterLoad()
    {
        dialogueScreen.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        loadingScreen.SetActive(false);
        
    }
    IEnumerator waiter()
    {
       
        yield return new WaitForSeconds(1.0f);
        checkIfToLoad();

    }


}
