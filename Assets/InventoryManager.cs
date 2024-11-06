using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public InventoryItem[] InventoryItems;
    private int inventoryLength = 10;

    public void Start()
    {
        InventoryItems = new InventoryItem[inventoryLength];
        for (int i = 0; i < inventoryLength; i++)
        {
            InventoryItems[i] = new InventoryItem();
            InventoryItems[i].ID = Random.Range(0,100);
            InventoryItems[i].Name = "Cool Item " + InventoryItems[i].ID;
            InventoryItems[i].Value = Random.Range(0, 100);
            Debug.Log(InventoryItems[i].Name);
            Debug.Log(InventoryItems[i].Value);
            Debug.Log(InventoryItems[i].ID);
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {

        return null;
    }

    public InventoryItem BinarySearchByID(int ID)
    {

    return null;
    }

    public InventoryItem QuickSortByValue(int Value)
    {
        
        return null;
    }
}