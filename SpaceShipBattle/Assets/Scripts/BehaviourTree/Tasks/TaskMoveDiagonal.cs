using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskMoveDiagonal : Node
    {
        private Rigidbody2D _rb;
        private float _speed;

        public TaskMoveDiagonal(Rigidbody2D rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }

        public override NodeState Evaluate()
        {
            _rb.velocity = new Vector2(1, -1).normalized * _speed;
            state = NodeState.SUCCESS;
            return state;
        }
    }
}