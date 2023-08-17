using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehaviour: MonoBehaviour, IWeapon
{
    public WeaponData weaponData;
    protected float time;
    
    protected void Start()
    {
        
    }
    protected void Update()
    {
        
    }

    public bool ApplyFireRate()
    {
        time += Time.deltaTime;
        return time > weaponData.fireRate;
    }

    public void Shoot()
    {
        GameObject tempBullet = Instantiate(weaponData.bullet,
            new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);

        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
        tempRigidBodyBullet.velocity = Vector2.up * weaponData.bulletSpeed;
        //tempBullet.GetComponent<BulletBehavior>().initialPosition =
        //    new Vector3(transform.position.x, transform.position.y, 0);
        //tempBullet.GetComponent<BulletBehavior>().weaponData = weaponData;
    }

    public abstract void ReloadWepapon();

}
