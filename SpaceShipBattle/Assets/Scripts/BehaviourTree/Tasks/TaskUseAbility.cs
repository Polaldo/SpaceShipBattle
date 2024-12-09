using Assets.Scripts.BehaviourTree;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskUseAbility : Node
{
    public IAbility ability;
    public float cooldownAbility;
    private float nextAbilityTime;

    public TaskUseAbility(IAbility ability, float cooldownAbility, ref float nextAbilityTime)
    {
        this.ability = ability;
        this.cooldownAbility = cooldownAbility;
        this.nextAbilityTime = nextAbilityTime;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("evalute task ability");
        if (Time.time >= cooldownAbility)
        {
            Debug.Log("inside if");
            ability.Use();
            Debug.Log("used ability");
            nextAbilityTime = Time.time + cooldownAbility;
            return NodeState.SUCCESS;
        }
        
        return NodeState.FAILURE;
    }
}
