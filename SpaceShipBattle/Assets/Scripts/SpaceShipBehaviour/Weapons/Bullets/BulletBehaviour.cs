using FMODUnity;
using UnityEngine;

public abstract class BulletBehaviour : MonoBehaviour, IBullet
{
    public int damage;
    private Vector3 initialPosition;
    protected float currentDistance;
    public string tagNotToCollide;
    public EventReference impactSound;

    protected Camera _camera;

    public float BulletDistance { get; set; }
    public Vector3 InitialPosition { get; set; }

    public abstract void DistanceBullet();

    protected virtual void Start()
    {
        _camera = Camera.main;
    }

    protected virtual void Update()
    {
        DestroyBulletIsOffScreenLimits();
        DistanceBullet();
    }

    public void DestroyBulletIsOffScreenLimits()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);

        if (CheckBulletOffScreenLimits(screenPosition))
        {
            Destroy(gameObject);
        }
    }

    public bool CheckBulletOffScreenLimits(Vector2 screenPosition)
    {
        return (screenPosition.x < 0 || screenPosition.x > _camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > _camera.pixelHeight);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null && !collision.gameObject.CompareTag(tagNotToCollide))
        {
            damageble.ApplyDamage(damage);
            Destroy(gameObject);
        }
    }
}

