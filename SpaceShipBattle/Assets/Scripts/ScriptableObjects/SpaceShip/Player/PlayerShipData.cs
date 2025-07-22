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

    [Header("Rank System")]
    public int currentRank;
    public int experienceToRanklUp;
    public int currentExperience;

    [Header("Economy")]
    public int galacticalCoins;
    public int darkShards;

    [Header("Inventory")]
    public List<ComponentShipData> inventory;
}
