using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private Image icon;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

    }
}
