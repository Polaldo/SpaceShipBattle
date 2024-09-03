using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tree;
using Assets.Scripts.BehaviourTree.Tasks;
using UnityEngine;

public class Zeta3BT : TreeBT<EnemyData>
{
    private Rigidbody2D _rb;
    private EnemyWeaponBehaviour _enemyWeaponBehaviour;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyWeaponBehaviour = GetComponent<EnemyWeaponBehaviour>();
    }

    protected override Node SetupTree()
    {
        Node root = new Selector( new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMove(this.GetComponent<Transform>(), _rb, shipData.speed),
                new TaskShoot(_enemyWeaponBehaviour),
            }),        
        });
            
            
            
        return root;
    }

}
