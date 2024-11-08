using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class InventoryManager : MonoBehaviour
{

    public InventoryItem[] InventoryItems;
    private int inventoryLength = 10;
    public int IDToFind;
    public bool BinarySearch, QuickSort;

    public void Start()
    {
        InventoryItems = new InventoryItem[inventoryLength];
        for (int i = 0; i < inventoryLength; i++)
        {
            InventoryItems[i] = new InventoryItem();
            InventoryItems[i].ID = UnityEngine.Random.Range(0, 100);
            InventoryItems[i].Name = "Cool Item " + InventoryItems[i].ID;
            InventoryItems[i].Value = UnityEngine.Random.Range(0, 100);
            //Debug.Log(InventoryItems[i].Name);
            //Debug.Log(InventoryItems[i].Value);
            //Debug.Log(InventoryItems[i].ID);
        }
        if (BinarySearch)
        {
            int IDFound = BinarySearchByID(InventoryItems, IDToFind);
            if (IDFound == -1) { Debug.LogWarning("ID Not Within Array"); }
            else { Debug.LogWarning("ID Found at" + IDFound + "In array"); }
        }

        if (QuickSort)
        {
            Debug.Log("Unsorted List");
            for (int i = 0; i < InventoryItems.Length; i++)
            {
                Debug.Log(InventoryItems[i].Name + " - Value: " + InventoryItems[i].Value);
            }

            QuickSortByValue(InventoryItems, 0, InventoryItems.Length - 1);

            Debug.Log("Sorted List");
            for (int i = 0; i < InventoryItems.Length; i++)
            {
                Debug.Log(InventoryItems[i].Name + " - Value: " + InventoryItems[i].Value);
            }
        }
    }

    public InventoryItem LinearSearchByName(string itemName)
    {
        for (int i = 0; i < inventoryLength; i++)
        {
            if (InventoryItems[i].Name == itemName)
                return InventoryItems[i];
        }
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

    public void QuickSortByValue(InventoryItem[] arr, int first, int last)
    {
        if (first < last)
        {
            int pivot = Partition(arr, first, last);

            QuickSortByValue(arr, first, pivot - 1);
            QuickSortByValue(arr, pivot + 1, last);
        }
    }

    public int Partition(InventoryItem[] arr, int first, int last)
    {
        int pivot = arr[last].Value;
        int smaller = first - 1;

        for (int element = first; element < last; element++)
        {
            if (arr[element].Value < pivot)
            {
                smaller++;
                // Swap arr[smaller] and arr[element]
                InventoryItem temp = arr[smaller];
                arr[smaller] = arr[element];
                arr[element] = temp;
            }
        }

        // Place pivot in the correct position
        InventoryItem tempNext = arr[smaller + 1];
        arr[smaller + 1] = arr[last];
        arr[last] = tempNext;

        return smaller + 1;
    }
}