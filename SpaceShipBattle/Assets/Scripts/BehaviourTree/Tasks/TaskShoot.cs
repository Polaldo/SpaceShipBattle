using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskShoot : Node
    {
        public EnemyWeaponBehaviour enemyWeapon;

        public TaskShoot(EnemyWeaponBehaviour enemyWeapon)
        {
            this.enemyWeapon = enemyWeapon;
        }

        public override NodeState Evaluate()
        {
            enemyWeapon.Shoot();
            state = NodeState.SUCCESS;
            return state;
        }
    }
}