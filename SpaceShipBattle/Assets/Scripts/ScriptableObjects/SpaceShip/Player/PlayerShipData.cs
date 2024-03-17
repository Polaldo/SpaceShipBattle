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

}
