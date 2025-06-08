using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Checks;
using Assets.Scripts.BehaviourTree.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class HakaishaBT : EnemyBT<EnemyData>
{
    IAbility ability;
    public float cooldownAbility = 10;
    public float distanceToBeTravelled = 1000;
    public float speed;
    public Transform targetToGo;
    public bool entranceIsFinished = false;

    protected override void Start()
    {
        ability = GetComponent<IAbility>();
        Debug.Log(targetToGo.position.y + " a");
        base.Start();
    }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {

            new Sequence (new List<Node>
            {
                new CheckCanShoot(targetToGo.position.y, transform),
                new TaskShoot(_enemyWeaponBehaviour),
                new Sequence (new List<Node> {
                    new CheckCanUseAbility(cooldownAbility),
                    new TaskUseAbility(ability),
                }),
            }),
             new TaskMoveToTarget(transform, _rb, speed, targetToGo.position.y)
        });

        return root;
    }
}
