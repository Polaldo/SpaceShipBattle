using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponBehaviour : WeaponBehaviour<PrimaryWeaponData>
{
    private void Update()
    {
        time += Time.deltaTime;
    }

    public virtual void Shoot()
    {
        if (ApplyFireRate())
        {
            GameObject tempBullet = GameObject.Instantiate(weaponData.bullet);
            if (tempBullet != null)
            {
                SetBulletData(tempBullet, Vector2.down, this.transform.position);
            }
            time = 0;
        }
    }

    public override bool ApplyFireRate()
    {
        return time > weaponData.fireRate;
    }

    public void SetBulletData(GameObject tempBullet, Vector2 target, Vector2 postionToSpawn)
    {
        tempBullet.transform.position = postionToSpawn;
        tempBullet.SetActive(true);

        Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
        tempRigidBodyBullet.velocity = target.normalized * weaponData.bulletSpeed;

        EnemyBulletBehaviour behaviour = tempBullet.GetComponent<EnemyBulletBehaviour>();
        behaviour.InitialPosition = transform.position;
        behaviour.BulletDistance = weaponData.bulletDistance;
        behaviour.damage = weaponData.damage;  
    }
}
