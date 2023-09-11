using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityWeaponData", menuName = "ScriptableObjects/WeaponData/AbilityWeaponData", order = 1)]
public class AbilityWeaponData : WeaponData
{
    public float timeRecharge;
    public int numberOfBullets;
}
