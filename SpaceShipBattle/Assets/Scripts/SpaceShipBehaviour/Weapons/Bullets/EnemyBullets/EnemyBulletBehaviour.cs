using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour
{
    public override void DistanceBullet()
    {
        currentDistance = Vector3.Distance(InitialPosition, transform.position);
        if (currentDistance >= BulletDistance)
        {
            Destroy(this.gameObject);
        }
    }
}
