using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class YScoutBT : EnemyBT<EnemyData>
{
    public Vector2 direction;
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMoveDiagonal(_rb, shipData.speed, direction),
                new TaskShoot(_enemyWeaponBehaviour),
                new CheckOutOffBounds(gameObject, healthController),
            }),
        });

        return root;
    }
}
