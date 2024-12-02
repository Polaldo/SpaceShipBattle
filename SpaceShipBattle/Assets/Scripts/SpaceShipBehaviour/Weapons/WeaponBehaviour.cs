using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour<T>: MonoBehaviour where T : WeaponData 
{
    public T weaponData;

    protected SpriteRenderer spriteRenderer;

    protected float time;

    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual bool ApplyFireRate()
    {
       throw new NotImplementedException();
    } 
}
