using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StationComponentInfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject componentInfoPanel;

    [Header("Info components UI")]
    [SerializeField] private Image sprite;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI speed;

    public void OpenComponentInfoPanel(ComponentShipData componentShipData)
    {
        SetComponentInfo(componentShipData);
        componentInfoPanel.gameObject.SetActive(true);
    }

    private void SetComponentInfo(ComponentShipData componentShipData)
    {
        sprite.sprite = componentShipData.sprite;
        health.text = componentShipData.health.ToString();
        attack.text = componentShipData.damage.ToString();
        defense.text = componentShipData.defense.ToString();
        speed.text = componentShipData.speed.ToString();
    }

    public void CloseComponent()
    {
        componentInfoPanel.gameObject.SetActive(false);
    }

    private void OpenListInventory()
    {
        
    }
}
