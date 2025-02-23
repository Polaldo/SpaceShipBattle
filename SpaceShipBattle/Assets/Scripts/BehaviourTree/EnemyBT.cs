using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tree;
using UnityEngine;

public class EnemyBT<T> : TreeBT where T : EnemyData
{
    public T shipData;
    protected Rigidbody2D _rb;
    protected EnemyWeaponBehaviour _enemyWeaponBehaviour;
    protected EnemyHealthController healthController;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyWeaponBehaviour = GetComponent<EnemyWeaponBehaviour>();
        healthController = GetComponent<EnemyHealthController>();
    }

    protected override Node SetupTree()
    {
        throw new System.NotImplementedException();
    }
}
