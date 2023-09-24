using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
            GameObject tempBullet = ObjectPool.SharedInstance.GetPooledObject();
            if (tempBullet != null)
            {
                tempBullet.transform.position = spawnsBullets[0].transform.position;
                tempBullet.transform.rotation = spawnsBullets[0].transform.rotation;
                tempBullet.SetActive(true);
            }

            SetBulletData(tempBullet);    
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
