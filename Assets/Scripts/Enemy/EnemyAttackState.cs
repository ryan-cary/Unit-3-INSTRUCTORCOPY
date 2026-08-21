using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        Debug.Log("Never should have come here!");
    }

    public override void OnStateExit()
    {

    }

    public override void OnStateUpdate()
    {

    }
}
