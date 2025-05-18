using Assets.Scripts.BehaviourTree;
using UnityEngine;

namespace Assets.Scripts.BehaviourTree.Tasks
{
    public class TaskUseAbility : Node
    {
        public IAbility ability;

        public TaskUseAbility(IAbility ability)
        {
            this.ability = ability;
        }

        public override NodeState Evaluate()
        {
            ability.Use();
            return NodeState.SUCCESS;
        }
    }
}