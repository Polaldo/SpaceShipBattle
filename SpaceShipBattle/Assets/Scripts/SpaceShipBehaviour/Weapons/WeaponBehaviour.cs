using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour<T>: MonoBehaviour, IShoot where T : WeaponData 
{
    public T weaponData;

    protected SpriteRenderer spriteRenderer;

    protected float time;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public abstract void Shoot();
}
