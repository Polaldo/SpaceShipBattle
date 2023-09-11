using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipData", menuName = "ScriptableObjects/PlayerShipData", order = 1)]
public class PlayerShipData : SpaceShipData
{
    public Sprite avatar;

    [Header("Sprites")]
    public Sprite baseShip;

    [Header("ComponentShip")]
    public PrimaryWeaponData primaryWeaponData;
    public EngineData engineData;
}
