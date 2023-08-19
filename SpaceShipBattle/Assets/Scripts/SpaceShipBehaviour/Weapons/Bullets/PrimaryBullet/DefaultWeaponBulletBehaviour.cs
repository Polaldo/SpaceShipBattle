using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultWeaponBulletBehaviour : BulletBehaviour
{

    private void Update()
    {
        DistanceBullet();
    }

    public override void DistanceBullet()
    {
        currentDistance = Vector3.Distance(InitialPosition, transform.position);
        if (currentDistance >= BulletDistance)
        {
            Destroy(gameObject);
        }
    }

}
