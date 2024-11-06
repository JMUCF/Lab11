using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public InventoryItem[] InventoryItems;
    private int inventoryLength = 10;
    public int IDToFind;
    public bool BinarySearch;

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
        if (BinarySearch)
        {
            int IDFound = BinarySearchByID(InventoryItems, IDToFind);
            if (IDFound == -1) { Debug.LogWarning("ID Not Within Array"); }
            else { Debug.LogWarning("ID Found at" + IDFound + "In array"); }
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {

        return null;
    }

    public int BinarySearchByID(InventoryItem[] arr, int ID)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid].ID == ID) return mid;

            else if (arr[mid].ID < ID) left = mid + 1;

            else right = mid - 1;
        }
        return -1;
    }

    public InventoryItem QuickSortByValue(int Value)
    {
        
        return null;
    }
}