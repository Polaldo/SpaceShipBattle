using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryListUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject inventoryListPanel;
    [SerializeField] private GameObject inventoryContent;
    [SerializeField] private List<ComponentShipData> inventory;

    [SerializeField]  private List<GameObject> itemUICreated;

    private void Start()
    {
        inventory = PlayerManager.Instance.shipData.inventory;
        itemUICreated = new List<GameObject>();
    }

    public void OpenInventory()
    {
        //CreateItemUI(inventory);
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
        Debug.Log($"Filtrando inventario por tipo: {filterType}");
        var filteredInventory = inventory.Where(item => item.GetType() == filterType).ToList();
        CreateItemUI(filteredInventory,filterComponent.id);
        inventoryListPanel.SetActive(true);
    }

    private void CreateItemUI(List<ComponentShipData> inventory, string idComponentEquip)
    {
        foreach (var item in inventory)
        {
            GameObject itemUIInstantiated = Instantiate(inventoryItemPrefab, inventoryContent.transform);
            itemUIInstantiated.GetComponent<InventoryItemUI>().SetItemData(item, item.id == idComponentEquip);
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
