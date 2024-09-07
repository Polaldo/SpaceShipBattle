using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponBehaviour : WeaponBehaviour<WeaponData>
{
    private void Update()
    {
        time += Time.deltaTime;
    }

    public override void Shoot()
    {
        if (ApplyFireRate())
        {
            GameObject tempBullet = GameObject.Instantiate(weaponData.bullet);
            if (tempBullet != null)
            {
                tempBullet.transform.position = this.transform.position;
                tempBullet.SetActive(true);
                SetBulletData(tempBullet);
            }
            time = 0;
        }
    }

    public override bool ApplyFireRate()
    {
        return time > 1;
    }

    public void SetBulletData(GameObject tempBullet)
    {
        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
        tempRigidBodyBullet.velocity = Vector2.down * weaponData.bulletSpeed;

        EnemyBulletBehaviour behaviour = tempBullet.GetComponent<EnemyBulletBehaviour>();
        behaviour.InitialPosition = transform.position;
        behaviour.BulletDistance = weaponData.bulletDistance;
        behaviour.damage = weaponData.damage;
    }
}
