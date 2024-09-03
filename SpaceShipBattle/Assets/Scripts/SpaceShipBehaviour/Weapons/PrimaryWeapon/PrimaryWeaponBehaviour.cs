using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PrimaryWeaponBehaviour : WeaponBehaviour<PrimaryWeaponData>
{
    public Transform[] spawnsBullets;
    private int resetIndex = 1; //because getComponentsInChildren also gets the parent tranform
    private int index;

    protected override void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = weaponData.primaryWeaponSprite;
        spawnsBullets = gameObject.GetComponentsInChildren<Transform>();
        index = resetIndex;
    }
    private void Update()
    {
        if (ApplyFireRate() && InputManager.Instance.GetInputMovePlayer().normalized != Vector2.zero)
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
            SetTransformTempBullet(tempBullet.transform);
            tempBullet.SetActive(true);

            SetBulletData(tempBullet);
        }      
    }

    public void SetTransformTempBullet(Transform bulletTransform)
    {
        bulletTransform.position = spawnsBullets[index].position;
        index = index >= spawnsBullets.Length -1 ? resetIndex : ++index;
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
