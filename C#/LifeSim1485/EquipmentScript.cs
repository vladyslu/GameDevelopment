using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public Inventory inventory;
    public ItemObject currentEquipment;
    public ItemObject startingEquipment;
    public ItemObject craftedEquipment;
    public ItemObject cookingEquipment;
    public ItemObject bartenderEquipment;
    public ItemObject carpenderEquipment;
    public ItemObject officialEquipment;
    public ItemObject smithEquipment;
    public ItemObject farmerEquipment;

    // Start is called before the first frame update
    void Start()
    {
        currentEquipment = startingEquipment; 
    }

    public void UpdateEquipment(ItemObject _item)
    {
        //inventory.addSomething(_item, -1);
        inventory.addSomething(currentEquipment, +1);
        currentEquipment = _item;

    }




    // Update is called once per frame
    void Update()
    {
       // Debug.Log(new Item(currentEquipment).Name);
        playerPrefab.transform.GetComponent<Image>().sprite = new Item(currentEquipment).buffs[0].appearance;
        
    }




}
