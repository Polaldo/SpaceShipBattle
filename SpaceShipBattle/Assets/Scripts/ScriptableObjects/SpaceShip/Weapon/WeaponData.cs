using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("Weapon")]
    public SpriteRenderer weaponSprite;
    public float fireRate;
    public float damage;
    [Header("Bullet")]
    public float bulletDistance;
    public float bulletSpeed;
    public GameObject bullet;

}
