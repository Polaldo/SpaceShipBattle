using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeaponBehaviour : WeaponBehaviour<PrimaryWeaponData>
{
    public Transform[] spawnsBullets;
    private void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = WeaponData.weaponSprite;
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
       return time > WeaponData.fireRate;
    }

    public override void Shoot()
    {
        for (int i = 0; i < spawnsBullets.Length; i++)
        {
            GameObject tempBullet = Instantiate(WeaponData.bullet,
            spawnsBullets[i].position, transform.rotation);

            SetBulletData(tempBullet);
        }      
    }

    public void SetBulletData(GameObject tempBullet)
    {
        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
        tempRigidBodyBullet.velocity = Vector2.up * WeaponData.bulletSpeed;

        DefaultWeaponBulletBehaviour behaviour = tempBullet.GetComponent<DefaultWeaponBulletBehaviour>();
        behaviour.InitialPosition = transform.position;
        behaviour.BulletDistance = WeaponData.bulletDistance;
        behaviour.Damage = WeaponData.damage;
    }
}
