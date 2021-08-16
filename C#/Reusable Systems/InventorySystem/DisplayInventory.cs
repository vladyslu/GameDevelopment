using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public InventoryScriptable inventoryScriptable;
    public MouseItem mouseItem = new MouseItem();
    public GameObject areYouSureToDestroyMenu;
    public GameObject ObjectDescriptionMenu;
  
    public EquipmentScript equipmentScript;
    public Inventory inventory;


    public int XspaceBetweenItems;
    public int columnNumber;
    public int YspaceBetweenItems;
    public int xStart;
    public int yStart;
    public GameObject inventoryPrefab;

    public ItemObject objectToEquip;
    public ItemObject objectToConsume;


    private ItemType FoodType = ItemType.Food;
    private ItemType EquipType = ItemType.Equipment;


    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    Item itemToDestroy; 

    // Start is called before the first frame update
    void Start()
    {
        //inventoryScriptable.Container.Items = new InventorySlot[28];
        CreateSlots();
    }




    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

   
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if(_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventoryScriptable.database.GetItem[_slot.Value.item.ID].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<Text>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
               if (_slot.Value.amount == 0)
               {
                    itemToDestroy = _slot.Value.item;
                    destoryTheObject();
               }
            }
            else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<Text>().text = "";
            }

            

        }




    }






    public void CreateSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventoryScriptable.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);


            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
            AddEvent(obj, EventTriggerType.PointerClick, delegate { OnClick(obj); });
            itemsDisplayed.Add(obj, inventoryScriptable.Container.Items[i]);
           
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



        if (itemsDisplayed[obj].ID >= 0)
        {
            

            //  var txt = mouseObject.AddComponent<Image>();
            ObjectDescriptionMenu.GetComponentInChildren<Text>().text =  inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID].description + "\nAmount: " + (inventoryScriptable.getAmount(new Item(inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID]))); 
            if(inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID].type == FoodType)
            {
              ObjectDescriptionMenu.transform.Find("ConsumeButoon").gameObject.SetActive(true);
                Item thisItem = new Item(inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID]);
                if (inventoryScriptable.getAmount(thisItem) >= 5)
                {
                    ObjectDescriptionMenu.transform.Find("ConsumeMultipleButoon").gameObject.SetActive(true);
                }
                

                objectToConsume = inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID];

            }
            else if (inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID].type == EquipType)
            {
                ObjectDescriptionMenu.transform.Find("EquipButton").gameObject.SetActive(true);

                objectToEquip = inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID];

            }
            else
            {
                ObjectDescriptionMenu.transform.Find("EquipButton").gameObject.SetActive(false);
                ObjectDescriptionMenu.transform.Find("ConsumeButoon").gameObject.SetActive(false);
                ObjectDescriptionMenu.transform.Find("ConsumeMultipleButoon").gameObject.SetActive(false);
            }
            
            

            ObjectDescriptionMenu.SetActive(true);

        }







    }

    public void equipObject()
    {
        equipmentScript.UpdateEquipment(objectToEquip);
        inventory.addSomethingNoLog(objectToEquip, -1);
        ObjectDescriptionMenu.SetActive(false);
    }

    public void consumeObject()
    {
        inventory.ConsumeItem(objectToConsume);
        ObjectDescriptionMenu.SetActive(false);
    }

    public void consumeObjectMultiple(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            inventory.ConsumeItem(objectToConsume);
        }
        ObjectDescriptionMenu.transform.Find("ConsumeMultipleButoon").gameObject.SetActive(true);
        ObjectDescriptionMenu.SetActive(false);
    }



    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverObj = obj; 
        if (itemsDisplayed.ContainsKey(obj))
        {
            mouseItem.hoverItem = itemsDisplayed[obj];

        }
    }

    public void OnExit(GameObject obj)
    {


        

        mouseItem.hoverObj = null;

        mouseItem.hoverItem = null;

        
    }


    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(1, 1);
        mouseObject.transform.SetParent(transform.parent);
        if(itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventoryScriptable.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            //img.transform.localScale = new Vector2(30, 30);
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
    
    }
    public void OnDragEnd(GameObject obj)
    {
        if (mouseItem.hoverObj)
        {

            inventoryScriptable.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]);


        }
        else
        {
            itemToDestroy = itemsDisplayed[obj].item;
            areYouSureToDestroyMenu.SetActive(true);

          //  inventoryScriptable.RemoveItem(itemsDisplayed[obj].item);
            
        }

        Destroy(mouseItem.obj);

        mouseItem.item = null;




    }


    public void destoryTheObject()
    {
        inventoryScriptable.RemoveItem(itemToDestroy);
    }








    public void OnDrag(GameObject obj)
    {
        if(mouseItem.obj != null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Camera.main.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        }
    }



    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (XspaceBetweenItems * (i %columnNumber)), yStart + (-YspaceBetweenItems * (i/columnNumber)), 0f);

    }



}


public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}