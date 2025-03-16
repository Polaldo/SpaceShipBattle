using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tasks;
using System.Collections.Generic;

public class HakaishaBT : EnemyBT<EnemyData>
{
    IAbility ability;
    public static float cooldownAbility = 10;

    protected override void Start()
    {
        ability = GetComponent<IAbility>();
        base.Start();
    }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskShoot(_enemyWeaponBehaviour),
                new TaskUseAbility(ability),
            }),
        });

        return root;
    }
}
