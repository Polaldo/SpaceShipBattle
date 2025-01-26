using Assets.Scripts.BehaviourTree.Tasks;
using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakaishaBT : EnemyBT<EnemyData>
{
    IAbility ability;
    public static float cooldownAbility = 10;

    protected override void Start()
    {
        ability = GetComponent<IAbility>();
        base.Start();        
    }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskUseAbility(ability),
            }),
            new Sequence (new List<Node> {
                new TaskShoot(_enemyWeaponBehaviour),
            }),           
        });

        return root;
    }
}
