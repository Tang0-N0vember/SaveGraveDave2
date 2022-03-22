using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
    [SerializeField] GameObject itemSlot1;
    [SerializeField] GameObject itemSlot2;
    [SerializeField] GameObject itemSlot3;
    [SerializeField] GameObject itemSlot4;
    [SerializeField] GameObject itemSlot5;
    [SerializeField] GameObject itemSlot6;

    private List<GameObject> itemSlots;
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        itemSlots = new List<GameObject>();
        itemSlots.Add(itemSlot1);
        itemSlots.Add(itemSlot2);
        itemSlots.Add(itemSlot3);
        itemSlots.Add(itemSlot4);
        itemSlots.Add(itemSlot5);
        itemSlots.Add(itemSlot6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
