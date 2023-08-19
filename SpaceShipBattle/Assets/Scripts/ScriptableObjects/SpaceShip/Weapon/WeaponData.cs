using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [Header("Weapon")]
    public Sprite weaponSprite;
    public float fireRate;
    public int damage;
    [Header("Bullet")]
    public float bulletDistance;
    public float bulletSpeed;
    public GameObject bullet;

}
