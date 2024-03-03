using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour<T>: MonoBehaviour, IShoot where T : WeaponData 
{
    public T weaponData;

    protected float time;

    public abstract void Shoot();
}
