using Assets.Scripts.BehaviourTree;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskUseAbility : Node
{
    public IAbility ability;
    private float cooldownAbility;
    float time;

    public TaskUseAbility(IAbility ability)
    {
        this.ability = ability;
        this.cooldownAbility = HakaishaBT.cooldownAbility;
    }

    public override NodeState Evaluate()
    {
        time += Time.deltaTime;
        if (time >= cooldownAbility)
        {
            ability.Use();
            time = 0;
            return NodeState.SUCCESS;
        }
        
        return NodeState.RUNNING;
    }
}
