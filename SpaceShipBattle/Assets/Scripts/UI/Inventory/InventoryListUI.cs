using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryListUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject inventoryListPanel;
    [SerializeField] private List<ComponentShipData> inventory;

    private List<GameObject> itemUICreated;

    private void Start()
    {
        inventory = PlayerManager.Instance.shipData.inventory;
        itemUICreated = new List<GameObject>();
    }

    public void OpenInventory()
    {
        CreateItemUI(inventory);
        inventoryListPanel.SetActive(true);
    }

    public void OpenInventoryWithFilter(ComponentShipData filterComponent)
    {
        if (filterComponent == null)
        {
            Debug.LogError("El componente de filtro es nulo.");
            return;
        }

        var filterType = filterComponent.GetType();
        var filteredInventory = inventory.Where(item => item.GetType() == filterType).ToList();
        CreateItemUI(filteredInventory);
        inventoryListPanel.SetActive(true);
    }

    private void CreateItemUI(List<ComponentShipData> item)
    {
        foreach (var itemUI in item)
        {
            GameObject itemUIInstantiated = Instantiate(inventoryItemPrefab, inventoryListPanel.transform);
            itemUIInstantiated.GetComponent<InventoryItemUI>().SetItemData(itemUI);
            itemUICreated.Add(itemUIInstantiated);
        }       
    }

    public void CloseInventory()
    {
        inventoryListPanel.SetActive(false);
        ClearItemUI();
    }

    private void ClearItemUI()
    {
        foreach (var item in itemUICreated)
        {
            Destroy(item);
        }
        itemUICreated.Clear();
    }   
}
