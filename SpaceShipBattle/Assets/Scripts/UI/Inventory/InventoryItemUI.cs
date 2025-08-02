using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image spriteIcon;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI inUseText;
    private ComponentShipData componentShipData;
    public void SetItemData(ComponentShipData componentShip, bool isItemEquip)
    {
        componentShipData = componentShip;
        spriteIcon.sprite = componentShip.sprite;

        if (isItemEquip)
        {
            button.interactable = false;
            inUseText.gameObject.SetActive(true);
        }

        button.onClick.AddListener(() => 
        {
            GameEventsManager.instance.playerEvents.EquipComponentShip(componentShipData);
        });
    }
}
