using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.BehaviourTree.Tree;
using Assets.Scripts.BehaviourTree;

public class EnemyBT<T> : TreeBT where T : EnemyData
{
    public T shipData;
    protected Rigidbody2D _rb;
    protected EnemyWeaponBehaviour _enemyWeaponBehaviour;

    protected void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _enemyWeaponBehaviour = GetComponent<EnemyWeaponBehaviour>();
    }

    protected override Node SetupTree()
    {
        throw new System.NotImplementedException();
    }
}
