using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Checks
{
    public class CheckCanUseAbility : Node
    {
        private float cooldownAbility;
        private float time;

        public CheckCanUseAbility(float cooldownAbility)
        {
            this.cooldownAbility = cooldownAbility;
        }

        public override NodeState Evaluate()
        {
            time += Time.deltaTime;
            if (time >= cooldownAbility)
            {
                time = 0;
                state = NodeState.SUCCESS;
            }
            else
            {
                state = NodeState.FAILURE;
            }
            return state;
        }
    }
}