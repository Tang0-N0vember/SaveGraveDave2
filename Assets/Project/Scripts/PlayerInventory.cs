using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    private List<Item> itemList;

    public PlayerInventory()
    {
        itemList = new List<Item>();

    }
}
