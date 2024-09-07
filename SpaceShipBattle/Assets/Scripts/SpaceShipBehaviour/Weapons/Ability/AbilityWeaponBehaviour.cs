using System;
using UnityEngine;

namespace Assets.Scripts.SpaceShipBehaviour.Ability
{
    public class AbilityWeaponBehaviour: WeaponBehaviour<AbilityWeaponData>, IAbility
    {
        protected override void Start()
        {
            base.Start();
            weaponData = PlayerManager.Instance.shipData.abilityWeaponData;
            setSpriteWeapon();
        }

        public void setSpriteWeapon()
        {
            spriteRenderer.sprite = weaponData.sprite;
        }

        public void Use()
        {
            Shoot();
        }

        public override void Shoot()
        {
            GameObject tempBullet = Instantiate(weaponData.bullet,
            new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
           
            SetBulletData(tempBullet);
        }

        public void SetBulletData(GameObject tempBullet)
        {
            Rigidbody2D tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody2D>();
            tempRigidBodyBullet.velocity = Vector2.up * weaponData.bulletSpeed;

            PrimaryBulletBehaviour behaviour = tempBullet.GetComponent<PrimaryBulletBehaviour>();
            behaviour.InitialPosition = transform.position;
            behaviour.BulletDistance = weaponData.bulletDistance;
            behaviour.damage = weaponData.damage;

        }
    }
}
