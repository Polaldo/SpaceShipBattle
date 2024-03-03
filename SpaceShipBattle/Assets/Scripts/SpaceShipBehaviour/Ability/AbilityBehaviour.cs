using System;
using UnityEngine;

namespace Assets.Scripts.SpaceShipBehaviour.Ability
{
    public class AbilityBehaviour: WeaponBehaviour<AbilityWeaponData>, ICooldown
    {
       
        private void Start()
        {
           weaponData = PlayerManager.Instance.shipData.abilityWeaponData;
        }

        private void Update()
        {
            if (InputManager.Instance.GetInputShoot() && ApplyCooldown())
            {
                time = 0;
                Shoot();
            }
            time += Time.deltaTime;
        }

        public bool ApplyCooldown()
        {
            return time > weaponData.cooldown;
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
