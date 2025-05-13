using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskMoveToTarget : Node
    {
        private Transform _transform;
        private Rigidbody2D _rb;
        private float _speed;
        private float distanceToBeTravelled;
        private float distanceTraveled;
        private bool initialized;
        private Vector2 previousPosition;

        public TaskMoveToTarget(Transform transform, Rigidbody2D rb, float speed, float target)
        {
            _transform = transform;
            _rb = rb;
            _speed = speed;
            distanceToBeTravelled = target;
        }

        public override NodeState Evaluate()
        {
            if (!initialized)
            {
                previousPosition = _transform.position;
                initialized = true;
            }

            if (Mathf.Approximately(_transform.position.y, distanceToBeTravelled) || _transform.position.y <= distanceToBeTravelled)
            {
                // Snap to the exact target position
                _transform.position = new Vector3(_transform.position.x, distanceToBeTravelled, _transform.position.z);
                SetData("hasGetToTarget", true);
                state = NodeState.SUCCESS;
            }
            else
            {
                float newY = Mathf.MoveTowards(_transform.position.y, distanceToBeTravelled, _speed * Time.deltaTime);
                Vector3 newPosition = new Vector3(_transform.position.x, newY, _transform.position.z);

                distanceTraveled += Vector3.Distance(previousPosition, newPosition);
                previousPosition = newPosition;

                _transform.position = newPosition;
                SetData("hasGetToTarget", false);
                state = NodeState.RUNNING;
            }

            Debug.Log($"Distance Traveled: {distanceTraveled:F2}");
            Debug.Log($"Current Y: {_transform.position.y:F2} | Target Y: {distanceToBeTravelled}");
            Debug.Log($"Node State: {state}");
            return state;
        }
    }
}