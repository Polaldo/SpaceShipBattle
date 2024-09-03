using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BehaviourTree.Tree;
using UnityEngine;

public class EnemyHealthController : HealthController
{
    protected override void Start()
    {
        Debug.Log(GetComponent<TreeBT<EnemyData>>());
        spaceShipData = GetComponent<TreeBT<EnemyData>>().shipData;
        
        base.Start();
    }
}
