using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class HakaishaBT : EnemyBT<EnemyData>
{
    IAbility ability;
    public static float cooldownAbility = 10;
    public static float distanceToBeTravelled = 1000;
    public float speed;
    public static Vector2 startPosition;
    public Transform targetToGo;

    protected override void Start()
    {
        ability = GetComponent<IAbility>();
        startPosition = transform.position;
        Debug.Log(targetToGo.position.y + " a");
        base.Start();
    }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            
            new Sequence (new List<Node>
            {
                new Sequence (new List<Node> {
                //    new TaskShoot(_enemyWeaponBehaviour),
                //    new TaskUseAbility(ability),
                new TaskShoot(_enemyWeaponBehaviour),
                }),              
                new TaskMoveToTarget(transform, _rb, speed, targetToGo.position.y)
            }),      
            
        });

        return root;
    }
}
