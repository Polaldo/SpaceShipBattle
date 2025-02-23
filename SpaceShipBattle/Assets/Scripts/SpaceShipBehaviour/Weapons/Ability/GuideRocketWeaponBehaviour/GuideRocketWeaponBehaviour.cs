using Assets.Scripts.SpaceShipBehaviour.Ability;
using Assets.Scripts.SpaceShipBehaviour.Weapons.Bullets.GuideRocketBullet;
using UnityEngine;

namespace Assets.Scripts.SpaceShipBehaviour.Weapons.Ability.GuideRocketWeaponBehaviour
{
    public class GuideRocketWeaponBehaviour : AbilityWeaponBehaviour
    {
        private new void Start()
        {
            //TODO: not implemented yet
        }

        public override void SetBulletData(GameObject tempBullet)
        {
            Debug.Log("set bullet rocket guide");
            GuideRocketBulletBehaviour behaviour = tempBullet.GetComponent<GuideRocketBulletBehaviour>();
            behaviour.InitialPosition = transform.position;
            behaviour.BulletDistance = weaponData.bulletDistance;
            behaviour.damage = weaponData.damage;
            behaviour.tagNotToCollide = this.tag;
        }
    }
}
