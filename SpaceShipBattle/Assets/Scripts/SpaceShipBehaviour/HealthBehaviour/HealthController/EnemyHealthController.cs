using UnityEngine;

public class EnemyHealthController : HealthController<EnemyData>
{
    protected override void Awake()
    {
        spaceShipData = GetComponent<EnemyBT<EnemyData>>().shipData;
        base.Awake();
    }

    protected override void Kill()
    {
        GetComponent<Collider2D>().enabled = false;
        LevelManager.Instance.AddPoints(spaceShipData.points);
        base.Kill();
    }
}
