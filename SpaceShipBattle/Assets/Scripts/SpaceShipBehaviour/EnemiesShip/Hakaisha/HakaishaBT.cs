using Assets.Scripts.BehaviourTree.Tasks;
using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HakaishaBT : EnemyBT
{
    IAbility ability;
    public float cooldownAbility;
    float nextAbilityTime = 0;

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
                new TaskUseAbility(ability, cooldownAbility, ref nextAbilityTime),
                //new TaskShoot(_enemyWeaponBehaviour),          
            }),     
        });

        return root;
    }
}
