using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tree
{
    public abstract class TreeBT<T> : MonoBehaviour where T : SpaceShipData
    {
        public T shipData;

        private Node _root = null;

        protected void Start()
        {
            _root = SetupTree();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}