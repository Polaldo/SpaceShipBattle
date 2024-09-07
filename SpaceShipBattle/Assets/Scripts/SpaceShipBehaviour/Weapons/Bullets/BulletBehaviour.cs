using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet
{
    private int damage;
    private Vector3 initialPosition;
    protected float currentDistance;
    public string tagNotToCollide;

    public float BulletDistance { get; set; }
    public Vector3 InitialPosition { get; set; }
    public int Damage { get; set; }

    public abstract void DistanceBullet();

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null && !collision.gameObject.CompareTag(tagNotToCollide))
        {
            damageble.ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}

