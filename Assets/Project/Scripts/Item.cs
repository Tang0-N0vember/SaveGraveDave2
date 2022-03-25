using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Item
{
    public ItemData itemData;
    public int stackSize;

    public Item(ItemData itemData)
    {
        this.itemData = itemData;
        AddToStack();

    }
    public void AddToStack()
    {
        stackSize++;
    }
    

}
