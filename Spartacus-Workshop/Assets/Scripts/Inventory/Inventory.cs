using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item[] _itemList = new Item[20];
    [SerializeField] private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    public bool Add(Item item)
    {
        for (int i = 0; i < _itemList.Length; i++)
        {
            if (_itemList[i] == null)
            {
                _itemList[i] = item;
                inventorySlots[i].ItemGS = item;
                return true;

            }
        }
        return false;
    }

    public void UpdateSlotUI()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].UpdateSlot();
        }
    }

    public void AddItem(Item item)
    {
        bool hasAdded = Add(item);
        if (hasAdded)
        {
            UpdateSlotUI();
        }
    }
}
