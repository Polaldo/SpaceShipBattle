using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public PlayerShipData shipData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CalculateAllStats();
    }

    public void CalculateAllStats()
    {
        ResetStats();

        List<ComponentShipData> components = new List<ComponentShipData>() {
            shipData.baseShipData, shipData.primaryWeaponData, shipData.abilityWeaponData, shipData.engineData
        };

        foreach (ComponentShipData component in components)
        {
            shipData.health += component.health;
            shipData.damage += component.damage;
            shipData.defense += component.defense;
            shipData.speed += component.speed;
        }
    }

    public void ResetStats()
    {
        shipData.health = 0;
        shipData.damage = 0;
        shipData.defense = 0;
        shipData.speed = 0;
    }
}
