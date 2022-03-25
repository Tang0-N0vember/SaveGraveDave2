using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance = null;

    //private PlayerInventory playerInventory;

    public int headCount, bodyCount, armCount, legCount;
    private void Awake()
    {
        if (instance == null) instance = this; else if (instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void LoadVillageSzene()
    {
        List<Item> inventory;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().GetInventoryList();
        foreach (Item item in inventory)
        {
            switch (item.itemData.itemType)
            {
                case ItemData.ItemType.Head:
                    headCount = item.stackSize;
                    break;
                case ItemData.ItemType.Body:
                    bodyCount = item.stackSize;
                    break;
                case ItemData.ItemType.Arm:
                    armCount = item.stackSize;
                    break;
                case ItemData.ItemType.Leg:
                    legCount = item.stackSize;
                    break;

            }
            //Debug.Log(item.stackSize);

            //headCount = inventory.
            SceneManager.LoadScene(3);
        }
    }
    public int GetHeadCount()
    {
        return headCount;
    }
}
