using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskMove : Node
    {
        private Transform _transform;
        private Rigidbody2D _rb;

        public TaskMove(Transform transform, Rigidbody2D rb)
        {
            _transform = transform;
            _rb = rb;
        }

        public override NodeState Evaluate()
        {

            _rb.velocity += Vector2.down * Zeta3BT.shipData.speed * Time.deltaTime;
            state = NodeState.SUCCESS;
            return state;
        }
    }
}