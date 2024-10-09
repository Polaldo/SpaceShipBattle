using Assets.Scripts.BehaviourTree.Tasks;
using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakaishaBT : EnemyBT
{
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskShoot(_enemyWeaponBehaviour),
            }),
        });

        return root;
    }
}
