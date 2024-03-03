using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipData", menuName = "ScriptableObjects/SpaceShip/PlayerShipData", order = 1)]
public class PlayerShipData : SpaceShipData
{
    public Sprite avatar;

    [Header("Sprites")]
    public Sprite baseShip;

    [Header("ComponentShip")]
    public BaseShipData baseShipData;
    public PrimaryWeaponData primaryWeaponData;
    public AbilityWeaponData abilityWeaponData;
    public EngineData engineData;

    public void CalculateTotalStats()
    {
        int totalHealth = health;
        int totalDamage = damage;
        int totalDefense = defense;
        float totalSpeed = speed;

        List<ComponentShipData> components = new List<ComponentShipData>() { 
            baseShipData, primaryWeaponData, abilityWeaponData, engineData
        };

        foreach (ComponentShipData component in components)
        {
            totalHealth += component.health;
            totalDamage += component.damage;
            totalDefense += component.defense;
            totalSpeed += component.speed;
        }

        health = totalHealth;
        damage = totalDamage;
        defense = totalDefense;
        speed = totalSpeed;
    }
}
