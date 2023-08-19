using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot();

    bool ApplyFireRate(); //TODO: change name of this method
}
