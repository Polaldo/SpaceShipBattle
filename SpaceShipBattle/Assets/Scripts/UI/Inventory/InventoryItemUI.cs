using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image spriteIcon;
    [SerializeField] private Button button;
    private ComponentShipData componentShipData;
    public void SetItemData(ComponentShipData componentShip)
    {
        componentShipData = componentShip;
        spriteIcon.sprite = componentShip.sprite;

        button.onClick.AddListener(() => 
        {
            GameEventsManager.instance.playerEvents.EquipComponentShip(componentShipData);
        });
    }
}
