using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tree
{
    public abstract class TreeBT : MonoBehaviour
    {
        private Node _root = null;

        protected virtual void Start()
        {
            _root = SetupTree();
        }

        protected virtual void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}