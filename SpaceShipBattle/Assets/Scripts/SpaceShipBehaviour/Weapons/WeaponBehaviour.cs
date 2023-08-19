using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour<T>: MonoBehaviour, IWeapon where T : WeaponData 
{
    private T weaponData;
    protected float time;

    public T WeaponData {get;}

    public abstract bool ApplyFireRate();

    public abstract void Shoot();
}
