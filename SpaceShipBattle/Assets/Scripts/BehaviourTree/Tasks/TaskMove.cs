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
        private float _speed;

        public TaskMove(Transform transform, Rigidbody2D rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }

        public override NodeState Evaluate()
        {
            _rb.velocity += Vector2.down * _speed * Time.deltaTime;
            state = NodeState.SUCCESS;
            return state;
        }
    }
}