using FMODUnity;
using UnityEngine;

public class WeaponData : ComponentShipData
{
    [Header("Sound")]
    public EventReference sfxBullet;
    public EventReference sfxImpact;

    [Header("Bullet")]
    public float bulletDistance;
    public float bulletSpeed;
    public GameObject bullet;
}
