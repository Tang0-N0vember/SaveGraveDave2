using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour,ICollectible
{
    public static event HandleBodyPartCollected OnBodyPartCollected;
    public delegate void HandleBodyPartCollected(ItemData itemData);
    public ItemData bodyData;
    public void Collect()
    {
        //Destroy(gameObject);
        OnBodyPartCollected?.Invoke(bodyData);
    }
}
