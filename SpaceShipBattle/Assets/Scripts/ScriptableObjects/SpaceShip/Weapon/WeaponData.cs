using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class WeaponData : ComponentShipData
{
    [Header("Bullet")]
    public float bulletDistance;
    public float bulletSpeed;
    public GameObject bullet;
}
