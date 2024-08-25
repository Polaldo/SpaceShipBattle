using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tree;
using Assets.Scripts.BehaviourTree.Tasks;
using UnityEngine;

public class Zeta3BT : Tree<EnemyData>
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override Node SetupTree()
    {
        Node root = new TaskMove(this.GetComponent<Transform>(), _rb);
        return root;
    }

}
