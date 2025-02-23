using Assets.Scripts.BehaviourTree;
using Assets.Scripts.BehaviourTree.Tasks;
using System.Collections.Generic;

public class Zeta3BT : EnemyBT<EnemyData>
{
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence (new List<Node> {
                new TaskMove(transform, _rb, shipData.speed),
                new TaskShoot(_enemyWeaponBehaviour),
                new CheckOutOffBounds(gameObject, healthController)
            }),
        });

        return root;
    }

}
