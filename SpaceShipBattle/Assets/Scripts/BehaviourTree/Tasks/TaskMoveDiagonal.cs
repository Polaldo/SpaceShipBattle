using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskMoveDiagonal : Node
    {
        private Rigidbody2D _rb;
        private float _speed;
        private Vector2 _direction;

        public TaskMoveDiagonal(Rigidbody2D rb, float speed, Vector2 direction)
        {
            _rb = rb;
            _speed = speed;
            _direction = direction;
        }

        public override NodeState Evaluate()
        {
            _rb.velocity = _direction.normalized * _speed;
            state = NodeState.SUCCESS;
            return state;
        }
    }
}