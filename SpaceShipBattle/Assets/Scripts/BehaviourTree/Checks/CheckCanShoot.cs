using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Checks
{
    public class CheckCanShoot : Node
    {
        private Transform _transform;
        private float distanceToBeTravelled;

        public CheckCanShoot(float distanceToBeTravelled, Transform t) {

            this._transform = t;
            this.distanceToBeTravelled = distanceToBeTravelled;
        }

        public override NodeState Evaluate()
        {
            if (Mathf.Approximately(_transform.position.y, distanceToBeTravelled) || _transform.position.y <= distanceToBeTravelled)
            {
                state = NodeState.SUCCESS;
            }
            else
            {
                state = NodeState.FAILURE;
            }
            Debug.Log("state can shoot " + state);
            return state;
        }
    }
}