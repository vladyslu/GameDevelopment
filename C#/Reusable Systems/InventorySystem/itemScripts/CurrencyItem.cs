using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Currency Object", menuName = "InventorySystem/Items/Currency")]
public class CurrencyItem : ItemObject
{

    public void Awake()
    {
        type = ItemType.Currency;
    }
}
