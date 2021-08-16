using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class VillageMarketSell : MonoBehaviour
{
    public Inventory inventory;
   // public GameObject mushroomButton;
   // public GameObject berriesButton;
   // public GameObject woodButton;
   // public GameObject AxeButton;



   // public Text mushroomsButtonText;
   // public Text woodButtonText;
   // public Text berriesButtonText;
   ////public Text axeButtonText;
   // public Text leatherButtonText;



    public GameObject inventoryPrefab;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    public MoneyManager moneyManager;


    // Start is called before the first frame update
    void Start()
    {
       // itemsDisplayed = new Dictionary<GameObject, InventorySlot>();

        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.inventoryScriptable.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);

            obj.GetComponent<RectTransform>().localPosition = new Vector3(80, -75, 0);



            //AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            //AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            //AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            //AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            //AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });

            itemsDisplayed.Add(obj, inventory.inventoryScriptable.Container.Items[i]);
        }



    }



    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);

    }



    public void OnClick(GameObject obj)
    {
        //  var mouseObject = new GameObject();
        //  var rt = mouseObject.AddComponent<RectTransform>();



        if (itemsDisplayed[obj].ID >= 1)
        {

            moneyManager.startSelling(inventory.inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID]);
         

        }







    }




    // Update is called once per frame
    void Update()
    {
        updateSlots();





        /*
        
       
        if (inventory.mushrooms.amount == 0)
        {
            mushroomButton.SetActive(false);
            
        }
        else
        {
            mushroomsButtonText.text = "   " + inventory.mushrooms + " mushroom";
            mushroomButton.SetActive(true);
           

        }

        if (inventory.berries.amount == 0)
        {
            berriesButton.SetActive(false);
        }
        else
        {
            berriesButtonText.text = "   " + inventory.berries + " berries";
            berriesButton.SetActive(true);
            
        }
        if (inventory.wood.amount == 0)
        {
            woodButton.SetActive(false);
            
        }
        else
        {
            woodButtonText.text = "   " + inventory.wood + " wood";
            woodButton.SetActive(true);
            
        }
/*
        if (inventory.axe.amount > 0)
        {
            AxeButton.SetActive(false);
        }
        else
        {
            AxeButton.SetActive(true);
        }
        */
    }


    public void updateSlots()
    {


        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
          //  Debug.Log("testID" + _slot.Value.ID);
            if (_slot.Value.ID >= 1)
            {
             //   Debug.Log("test");
                _slot.Key.gameObject.SetActive(true);
                // _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventoryScriptable.database.GetItem[_slot.Value.item.ID].uiDisplay;
                //  _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<Text>().text = "       " + _slot.Value.amount + " " + _slot.Value.item.Name;
                if (_slot.Value.amount == 0)
                {
                    //itemToDestroy = _slot.Value.item;
                    // destoryTheObject();
                    _slot.Key.gameObject.SetActive(false);

                }
            }
            else
            {
                //    _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                //    _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<Text>().text = "";
            }



        }

    }

}
