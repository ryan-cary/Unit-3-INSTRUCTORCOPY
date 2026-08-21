using Unity.Android.Types;
using UnityEngine;

public class EnemyPatrolState : EnemyState
{
    int currentTarget = 0;

    public EnemyPatrolState(Enemy enemy) : base(enemy)
    {

    }

    public override void OnStateEnter()
    {
        _enemy.agent.SetDestination(_enemy.patrolPoints[currentTarget].position);
    }

    public override void OnStateExit()
    {
        Debug.Log("Huh?");
    }

    public override void OnStateUpdate()
    {
        Patrol();
        if (ShouldTransitionToFollow())
            TransitionToFollow();
    }

    private void Patrol()
    {
        if (_enemy.agent.remainingDistance < 0.1f)
        {
            //target reached
            currentTarget = GetNextTarget();
            _enemy.agent.SetDestination(GetTargetPosition());
        }
    }

    private bool ShouldTransitionToFollow()
    {
        if (Physics.SphereCast(_enemy.EnemyEye.position, _enemy.sightRadius, _enemy.transform.forward, out RaycastHit info, _enemy.sightDistance))
        {
            if (info.transform.CompareTag("Player"))
            {
                _enemy.player = info.transform;
                return true;
            }
            
        }
        return false;
    }

    private void TransitionToFollow()
    {
        _enemy.agent.SetDestination(_enemy.player.position);
        _enemy.ChangeState(new EnemyFollowState(_enemy));
    }

    private int GetNextTarget()
    { return (currentTarget + 1) % _enemy.patrolPoints.Length; }
    private Vector3 GetTargetPosition()
    { return _enemy.patrolPoints[currentTarget].position; }
}
