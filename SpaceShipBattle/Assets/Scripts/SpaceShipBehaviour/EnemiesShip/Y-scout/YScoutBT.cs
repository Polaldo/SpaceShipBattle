using Assets.Scripts.BehaviourTree.Tasks;
using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YScoutBT : EnemyBT
{
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMove(this.GetComponent<Transform>(), _rb, shipData.speed),
                new TaskShoot(_enemyWeaponBehaviour),
            }),
        });

        return root;
    }
}
