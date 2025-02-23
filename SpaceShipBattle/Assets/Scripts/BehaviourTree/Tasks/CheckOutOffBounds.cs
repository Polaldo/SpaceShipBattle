using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class CheckOutOffBounds : Node
    {
        private Camera _camera;
        private GameObject _gameObject;
        private EnemyHealthController _healthController;
        private int offSetBounds = -100;

        public CheckOutOffBounds(GameObject gB, EnemyHealthController healthController)
        {
            _camera = Camera.main;
            _gameObject = gB;
            _healthController = healthController;
        }

        public override NodeState Evaluate()
        {
            Vector2 screenPosition = _camera.WorldToScreenPoint(_gameObject.transform.position);
            if (screenPosition.y < offSetBounds)
            {
                _healthController.DestroyObject();
            }
            return NodeState.RUNNING;
        }

    }
}
