using UnityEngine;

public class PrimaryBulletBehaviour : BulletBehaviour
{

    protected override void Update()
    {
        DistanceBullet();
    }

    public override void DistanceBullet()
    {
        Vector2 screenPosition = _camera.WorldToScreenPoint(transform.position);
        currentDistance = Vector3.Distance(InitialPosition, transform.position);
        if (currentDistance >= BulletDistance || CheckBulletOffScreenLimits(screenPosition))
        {
            gameObject.SetActive(false);
        }
    }

    protected new void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageble damageble = collision.gameObject.GetComponent<IDamageble>();
        if (damageble != null && !collision.gameObject.CompareTag(tagNotToCollide))
        {
            damageble.ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }

}
