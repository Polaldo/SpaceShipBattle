using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUseAbility : Node
{
    public IAbility ability;
    public float cooldownAbility;
    float time;

    public TaskUseAbility(IAbility ability, float cooldownAbility, ref float time)
    {
        if (ability == null)
        {
            Debug.LogError("TaskAbility received a null reference!");
        }
        this.ability = ability;
        //this.cooldownAbility = cooldownAbility;
        this.time = time;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("evalute task ability" );
        if (time >= cooldownAbility)
        {
            Debug.Log("inside if");
            ability.Use();
            Debug.Log("used ability");
            time = 0;
            return NodeState.SUCCESS;
        }
        
        return NodeState.FAILURE;
    }
}
