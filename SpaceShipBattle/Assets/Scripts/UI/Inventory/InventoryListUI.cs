using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryListUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private List<ComponentShipData> inventory;

    private void Start()
    {
        inventory = PlayerManager.Instance.shipData.inventory;
    }

    public void OpenInventory()
    {

    }

    public void OpenInventoryWithFilter()
    {

    }

}
