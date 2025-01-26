using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tree;
using Assets.Scripts.BehaviourTree.Tasks;
using UnityEngine;

public class Zeta3BT : EnemyBT<EnemyData>
{
    protected override Node SetupTree()
    {      
        Node root = new Selector( new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMove(null, _rb, shipData.speed),
                new TaskShoot(_enemyWeaponBehaviour),
                new CheckOutOffBounds(gameObject, healthController)
            }),
        });
        
        return root;
    }

}
