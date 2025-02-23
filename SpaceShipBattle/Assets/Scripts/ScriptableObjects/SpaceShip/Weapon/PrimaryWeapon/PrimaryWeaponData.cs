using UnityEngine;

[CreateAssetMenu(fileName = "PrimaryWeaponData", menuName = "ScriptableObjects/ComponentShip/WeaponData/PrimaryWeaponData", order = 2)]
public class PrimaryWeaponData : WeaponData
{
    public Sprite primaryWeaponSprite;
    public float fireRate;
}
