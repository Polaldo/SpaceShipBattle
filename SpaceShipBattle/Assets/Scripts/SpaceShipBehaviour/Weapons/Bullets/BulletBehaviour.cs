using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet
{
    private int damage;
    private Vector3 initialPosition;
    protected float currentDistance;

    public float BulletDistance { get; set; }
    public Vector3 InitialPosition { get; set; }
    public int Damage { get; set; }

    protected void Start()
    {
        DestroyBulletPassedTime();
    }

    public abstract void DistanceBullet();

    public void DestroyBulletPassedTime()
    {
        Destroy(gameObject,5);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null)
        {
            damageble.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}
