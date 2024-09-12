using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.BehaviourTree.Tree;
using UnityEngine;

public class EnemyHealthController : HealthController
{
    protected override void Start()
    {
        spaceShipData = GetComponent<EnemyBT>().shipData;
        
        base.Start();
    }
}
