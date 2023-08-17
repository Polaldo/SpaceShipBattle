using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerShipData", menuName = "ScriptableObjects/PlayerShipData", order = 1)]
public class AbilityWeaponData : WeaponData
{
    public float timeRecharge;
    public int numberOfBullets;
}
