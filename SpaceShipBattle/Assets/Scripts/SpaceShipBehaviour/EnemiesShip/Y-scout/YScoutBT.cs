using Assets.Scripts.BehaviourTree.Tasks;
using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YScoutBT : EnemyBT<EnemyData>
{
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMoveDiagonal(_rb, shipData.speed),
                new TaskShoot(_enemyWeaponBehaviour),
            }),
            new CheckOutOffBounds(gameObject, healthController),
        });

        return root;
    }
}
