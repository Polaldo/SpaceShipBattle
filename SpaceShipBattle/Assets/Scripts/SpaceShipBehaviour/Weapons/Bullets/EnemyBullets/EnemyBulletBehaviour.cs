using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour
{
    void Update()
    {
        DistanceBullet();
    }

    public override void DistanceBullet()
    {
        currentDistance = Vector3.Distance(InitialPosition, transform.position);
        if (currentDistance >= BulletDistance)
        {
            //gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
