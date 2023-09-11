using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponBehaviour : WeaponBehaviour<PrimaryWeaponData>
{
    public Transform[] spawnsBullets;
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = weaponData.primaryWeaponSprite;
    }
    private void Update()
    {
        if (InputManager.Instance.GetInputShoot() && ApplyFireRate())
        {
            time = 0;
            Shoot();
        }
        time += Time.deltaTime;
    }

    public override bool ApplyFireRate()
    {
       return time > weaponData.fireRate;
    }

    public override void Shoot()
    {
        for (int i = 0; i < spawnsBullets.Length; i++)
        {
            GameObject tempBullet = Instantiate(weaponData.bullet,
            spawnsBullets[i].position, transform.rotation);

            SetBulletData(tempBullet);
        }      
    }

    public void SetBulletData(GameObject tempBullet)
    {
        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
        tempRigidBodyBullet.velocity = Vector2.up * weaponData.bulletSpeed;

        PrimaryBulletBehaviour behaviour = tempBullet.GetComponent<PrimaryBulletBehaviour>();
        behaviour.InitialPosition = transform.position;
        behaviour.BulletDistance = weaponData.bulletDistance;
        behaviour.Damage = weaponData.damage;
    }
}
