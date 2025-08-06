using Assets.Scripts.Gold;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopUI : MonoBehaviour
{
    [SerializeField] private ComponentShipData item;
    [Header("UI elements")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Image spriteItem;
    [SerializeField] private Image iconPrice;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI soldOutText;

    private void Start()
    {
        SetDataItem();
        buyButton.onClick.AddListener(BuyItem);
    }
     
    private void SetDataItem()
    {
        priceText.text = item.price.ToString();
        spriteItem.sprite = item.sprite;
    }

    private void BuyItem()
    {
        if (GoldManager.Instance.currentGold < item.price)
        {
            Debug.Log("Not enough coins to buy this item.");
            return;
        }
        GameEventsManager.instance.playerEvents.BoughtComponetShipItem(item);
        buyButton.onClick.RemoveAllListeners();
        priceText.gameObject.SetActive(false);
        iconPrice.gameObject.SetActive(false);
        spriteItem.gameObject.SetActive(false);
        soldOutText.gameObject.SetActive(true); 
    }
}
