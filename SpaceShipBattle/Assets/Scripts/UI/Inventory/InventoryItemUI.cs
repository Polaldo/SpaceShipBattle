using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    [SerializeField] private Image spriteIcon;
    public void SetItemData(ComponentShipData componentShip)
    {
        spriteIcon.sprite = componentShip.sprite;
    }
}
