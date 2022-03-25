using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Item> invetory=new List<Item>();
    public Dictionary<ItemData, Item> itemDictionary=new Dictionary<ItemData, Item>();

    private void OnEnable()
    {
        BodyPart.OnBodyPartCollected += Add;
    }
    private void OnDisable()
    {
        BodyPart.OnBodyPartCollected -= Add;
    }

    public void Add(ItemData itemData)
    {
        if(itemDictionary.TryGetValue(itemData,out Item item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.itemType} total stack is now {item.stackSize}");
        }
        else
        {
            Item newItem = new Item(itemData);
            invetory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.itemType} to the inventory for the first time");
        }
    }
    public bool IsBodyMissing()
    {
        return true;
    }
    public bool IsHeadMissing()
    {
        return true;
    }
    public bool IsArmMissing()
    {
        return true;
    }
    public bool IsLegMissing()
    {
        return true;
    }
    public List<Item> GetInventoryList()
    {
        return invetory;
    }
    public Dictionary<ItemData, Item> GetItemDictionary()
    {
        return itemDictionary;
    }

}
