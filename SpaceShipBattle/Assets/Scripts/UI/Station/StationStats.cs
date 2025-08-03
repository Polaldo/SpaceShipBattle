using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StationStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private TextMeshProUGUI attack;
    [SerializeField] private TextMeshProUGUI defense;
    [SerializeField] private TextMeshProUGUI speed;

    private void Start()
    {
        UpdateStats(PlayerManager.Instance.shipData);
    }

    private void OnEnable()
    {   
        GameEventsManager.instance.playerEvents.onChangeShipStats += UpdateStats;
    }

    private void UpdateStats(PlayerShipData shipData)
    {
        health.text = shipData.health.ToString();
        attack.text = shipData.damage.ToString();
        defense.text = shipData.defense.ToString();
        speed.text = shipData.speed.ToString();
    }

    private void OnDisable()
    {
        GameEventsManager.instance.playerEvents.onChangeShipStats -= UpdateStats;
    }
}
