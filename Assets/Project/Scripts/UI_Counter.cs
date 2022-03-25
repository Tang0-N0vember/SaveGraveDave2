using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI headText, bodyText, armText, legText;

    private int headCount, bodyCount, armCount, legCount;

    private void OnEnable()
    {
        BodyPart.OnBodyPartCollected += IncrementBodyPartCount;
    }
    private void OnDisable()
    {
        BodyPart.OnBodyPartCollected -= IncrementBodyPartCount;
    }

    private void IncrementBodyPartCount(ItemData itemData)
    {
        switch (itemData.itemType)
        {
            case ItemData.ItemType.Head:
                headCount++;
                headText.text = $"{headCount}";
                break;
            case ItemData.ItemType.Body:
                bodyCount++;
                bodyText.text = $"{bodyCount}";
                break;
            case ItemData.ItemType.Arm:
                armCount++;
                armText.text = $"{armCount}";
                break;
            case ItemData.ItemType.Leg:
                legCount++;
                legText.text = $"{legCount}";
                break;
        }
    }
}
