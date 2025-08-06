using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopControllerUI : MonoBehaviour
{

    private void OnEnable()
    {
        GameEventsManager.instance.playerEvents.onBoughtComponetShipItem += BoughtComponentShipItem;
    }

    private void BoughtComponentShipItem(ComponentShipData item)
    {
        GameEventsManager.instance.economyEvents.GalacticalCoinsChange(-item.price);
        GameEventsManager.instance.playerEvents.AddItemInventory(item);
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onBoughtComponetShipItem -= BoughtComponentShipItem;
    }
}
